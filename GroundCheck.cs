using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;
    public LayerMask whatIsGround;

    private void OnTriggerStay2D(Collider2D collider)
    {
        isGrounded = collider != null && (((1 << collider.gameObject.layer) & whatIsGround) != 0);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
