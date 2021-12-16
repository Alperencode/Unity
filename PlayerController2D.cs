using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    // Variables
    public float Speed;
    public ParticleSystem rightDust;
    public ParticleSystem leftDust;
    private Animator animator;
    private Rigidbody2D rb;
    private CapsuleCollider2D capsule;
    private AudioSource audioSource;
    private float moveInput;
    private bool FacingRight;
    private bool isMoving;

    // Jumping Variables
    public int extraJumps;
    public float radius;
    public float jumpforce;
    public LayerMask whatisGround;
    public BoxCollider2D box;
    private int extraJumpValue;
    public float vertical;

    private void Start()
    {
        // Gathering components
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        capsule = GetComponent<CapsuleCollider2D>();
        audioSource = GetComponent<AudioSource>();

        // Setting the starting values
        FacingRight = true;
        extraJumpValue = extraJumps;
        
    }

    private void FixedUpdate()
    {
        

        // Movement
        moveInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        rb.velocity = new Vector2(moveInput * Speed, rb.velocity.y);

        if (FacingRight == true && moveInput < 0){
            Flip();
        }
        else if (FacingRight == false && moveInput > 0){
            Flip();
        }
        // End of movement
        
        // isMoving Check
        if (rb.velocity.x != 0){
            isMoving = true;
        }else{
            isMoving = false;
        }

        // Setting the audio
        if (isMoving && isGrounded()){

            if (!audioSource.isPlaying){
                audioSource.Play();
            }
        }else{
            audioSource.Stop();
        }

        // Setting Dust mechanic (Particles)
        if (FacingRight && isMoving && isGrounded()){
            StopLeft();
            RightDust();
        }else if (!FacingRight && isMoving && isGrounded() ){
            StopRight();
            LeftDust();
        }else if (!isMoving){
            StopRight();
            StopLeft();
        }
    }

    void Update()
    {
        // Jumping
        vertical = rb.velocity.y;
        if (isGrounded()){
            vertical = 0;
            animator.SetBool("isJumping", false);
            extraJumpValue = extraJumps;
        }
        
        animator.SetFloat("Vertical", vertical);
        animator.SetBool("isJumping", !isGrounded());

        if (Input.GetKeyDown(KeyCode.W) && extraJumpValue > 0){
            Soundmanager.PlaySound("Jump");
            rb.velocity = Vector2.up * jumpforce;
            extraJumpValue -= 1;
        }


    }

    // Functions
    void StopRight(){
        rightDust.Stop();
    }
    
    void StopLeft(){
        leftDust.Stop();
    }

    void RightDust(){
        rightDust.Play();
    }

    void LeftDust(){
        leftDust.Play();
    }
    
    void Flip(){
        FacingRight = !FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    // isGrounded function
    private bool isGrounded(){
        // --- Box Collider Check w/Raycast ---
        float extraHeight = 0.5f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, extraHeight, whatisGround);
        // RaycastHit2D tryhit = Physics2D.CapsuleCast(capsule.bounds.center, capsule.bounds.size, "Vertical", 0f, Vector2.down, extraHeight, whatisGround); 

        // --- Raycast Coloring ---
        Color raycastColor;
        if (raycastHit.collider != null)
        {
            raycastColor = Color.green;
        }
        else
        {
            raycastColor = Color.red;
        }

        // --- Draw Gizmos ---
        Debug.DrawRay(box.bounds.center + new Vector3(box.bounds.extents.x, 0), Vector2.down * (box.bounds.extents.y + extraHeight), raycastColor);
        Debug.DrawRay(box.bounds.center - new Vector3(box.bounds.extents.x, 0), Vector2.down * (box.bounds.extents.y + extraHeight), raycastColor);
        Debug.DrawRay(box.bounds.center - new Vector3(box.bounds.extents.x, box.bounds.extents.y), Vector2.right * (box.bounds.extents.x), raycastColor);

        return raycastHit.collider != null;
    }
}


