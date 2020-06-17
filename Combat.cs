using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public int hp;
    public int maxHp;
    public int damage;

    private void Start()
    {
        maxHp = 100;
        hp = maxHp;
        damage = 20;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Death();
        }
    }

    private void FixedUpdate()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetFloat("Speed", 0);
        }
    }

    void Attack()
    {
        Soundmanager.PlaySound("Attack");  // Sound
        animator.SetTrigger("Attack");  // Animation
        // Detect the enemies
        // Damage to them
    }

    void Death()
    {
        Soundmanager.PlaySound("Death");
        animator.SetTrigger("Death");
    }
}
