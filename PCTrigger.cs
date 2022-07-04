using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCTrigger: MonoBehaviour
{
    //public Animator anim;
    public GameObject trigger;

    bool enter;

    public float enterRate = 2f;

    void Start()
    {
        enter = false;
        trigger.SetActive(false);
    }
    void Update()
    {
            if (enter == true && Input.GetKeyDown(KeyCode.F))
            {
                trigger.SetActive(!trigger.activeInHierarchy);
            }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            enter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            enter = false;
        }
    }

}