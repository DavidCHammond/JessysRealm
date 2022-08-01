using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody p_Rigidbody;
    public float p_Force = 20f;
    bool willMove;
    // Start is called before the first frame update
    void Start()
    {
        p_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.rPunch && willMove)
        {
            p_Rigidbody.AddForce(transform.right * p_Force);
        }
        if (PlayerMovement.lPunch && willMove)
        {
            p_Rigidbody.AddForce(transform.up * p_Force);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("R_Arms"))
        {
            willMove = true;
            Debug.Log("Hit");
        }
        if (collision.CompareTag("L_Arms"))
        {
            willMove = true;
            Debug.Log("Hit");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("R_Arms"))
        {
            willMove = false;
        }
        if (collision.CompareTag("L_Arms"))
        {
            willMove = false;
        }
    }
}
