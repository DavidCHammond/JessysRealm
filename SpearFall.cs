using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearFall : MonoBehaviour
{
    public float speed = 10.0f;

    public Vector3 start;
    public Vector3 moveTo;
    public Vector3 current;

    public GameObject Hint;

    private bool willFall;
    void Start()
    {
        Hint.SetActive(false);
        willFall = false;
    }
    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        if (transform.position == start && willFall)
        {
            current = moveTo;
            transform.position = moveTo;
            Hint.SetActive(true);
        }
        if(PlayerMovement.hasDied)
        {
            current = start;
            transform.position = start;
            Hint.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            willFall = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            willFall = false;
        }
    }
}
