using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk2Center : MonoBehaviour
{
    public static bool isCenter;
    bool walkLeft;
    bool walkRight;

    private Animator anim;
    private Rigidbody2D body;

    public float speed = 2f;

    public Vector3 center;
    public Vector3 current;

    public GameObject portalPlat;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        isCenter = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (JessyTeleport.willWalk && walkLeft)
        {
            WalkLeft();
        }
        if (JessyTeleport.willWalk && walkRight)
        {
            WalkRight();
        }
    }
    void WalkRight()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, current, step);
        if (JessyTeleport.willWalk)
        {
            current = center;
            anim.SetTrigger("R_Walk");
        }
        if (transform.position == center)
        {
            isCenter = true;
        }
    }
    void WalkLeft()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, current, step);
        if (JessyTeleport.willWalk)
        {
            current = center;
            anim.SetTrigger("L_Walk");
        }
        if(transform.position == center)
        {
            isCenter = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Right"))
        {
            walkLeft = true;
        }
        if(collision.CompareTag("Left"))
        {
            walkRight = true;
        }
        if(collision.CompareTag("Plat"))
        {
            PlayerMovement.MoveIsEnabled = false;
            PlayerMovement.IsInputEnabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Right"))
        {
            walkLeft = false;
        }
        if (collision.CompareTag("Left"))
        {
            walkRight = false;
        }
    }
}
