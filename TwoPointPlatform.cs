using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPointPlatform : MonoBehaviour
{
    public float speed = 10.0f;

    public Vector3 startPosition;
    public Vector3 target1;
    private Vector3 current;

    // Update is called once per frame
    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        if (transform.position == startPosition)
        {
            current = target1;
        }
        else if (transform.position == target1)
        {
            current = startPosition;
        }
        transform.position = Vector3.MoveTowards(transform.position, current, step);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = this.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
