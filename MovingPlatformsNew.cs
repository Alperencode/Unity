using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformsNew : MonoBehaviour
{
    public float speed;
    private bool moveRight;

    private void Update()
    {
        if (transform.position.x > 4f)
        {
            moveRight = false;
        }
        else if (transform.position.x < -4f)
        {
            moveRight = true;
        }
        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }            
    }
}
