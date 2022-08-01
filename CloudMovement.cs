using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float speed = 10.0f;
    private bool restart;
    public Transform spawn;
    private Vector3 spawnPos;

    private void Awake()
    {
        spawnPos = spawn.position;
    }


    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;
        if (!restart)
        {
            transform.Translate(Vector3.right * step);
        }
        else if (restart)
        {
            transform.position = spawnPos;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("End"))
        {
            restart = true;
        }
        if (collision.CompareTag("Start"))
        {
            restart = false;
        }
    }
}
