using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitterBoxTrigger : MonoBehaviour
{
    public Animator anim;

    public float speed = 10.0f;

    bool enter;

    float nextEnter = 0f;
    public float enterRate = 2f;

    public Vector2 target;
    public Vector2 position;

    void Start()
    {
        enter = false;
        position = new Vector2(4.38f, -1.357f);
        position = gameObject.transform.position;
    }
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (Time.time >= nextEnter)
        {
            PlayerMovement.IsInputEnabled = false;
            if (enter == true && Input.GetKeyDown(KeyCode.F))
            {

                transform.position = Vector2.MoveTowards(transform.position, target, step);
                Debug.Log("You may use");
                anim.SetTrigger("Enter");
                nextEnter = Time.time + 1f / enterRate;
            }
        }
        if (Time.time >= nextEnter)
        {
            PlayerMovement.IsInputEnabled = true;
            Combat.IsInputEnabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Litter Box"))
        {
            enter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Litter Box"))
        {
            enter = false;
        }
    }

}