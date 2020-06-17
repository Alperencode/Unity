using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public Transform pos1,pos2;
    public float speed;

    Vector3 nextPos;

    private void Start()
    {
        nextPos = pos1.position;
    }

    private void Update()
    {
        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }else if(transform.position == pos2.position){
            nextPos = pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.collider.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
