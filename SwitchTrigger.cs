using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    public Animator anim;
    public GameObject night;
    public GameObject clouds;

    bool enter;


    void Start()
    {
        enter = false;
        night.SetActive(false);
        clouds.SetActive(true);
    }
    void Update()
    {
        if (enter == true && Input.GetKeyDown(KeyCode.F))
        {
            night.SetActive(!night.activeInHierarchy);
            clouds.SetActive(!night.activeInHierarchy);
            anim.Play("Switch");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Switch"))
        {
            enter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Switch"))
        {
            enter = false;
        }
    }

}