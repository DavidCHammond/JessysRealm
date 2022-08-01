using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float speed = 10.0f;
    public Vector3 platformStart;
    public Vector3 moveTo;
    private Vector3 current;

    private bool willFall;
    void Start()
    {
        willFall = false;
    }
        void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        if (willFall)
        {
            current = moveTo;
            transform.position = Vector3.MoveTowards(transform.position, current, step);
        }
        if(PlayerMovement.hasDied)
        {
            transform.position = platformStart;
        }
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            willFall = true;
            collision.transform.parent = this.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            willFall = false;
            collision.transform.parent = this.transform;
        }
    }
}
