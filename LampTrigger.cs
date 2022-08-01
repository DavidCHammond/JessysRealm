using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampTrigger : MonoBehaviour
{
    public Animator anim;

    public GameObject Yellow;
    public GameObject Red;
    public GameObject Blue;
    public GameObject Green;
    public GameObject Pink;

    bool enter;


    void Start()
    {
        Time.timeScale = 1f;
        enter = false;
        Red.SetActive(false);
        Blue.SetActive(false);
        Green.SetActive(false);
        Pink.SetActive(false);
    }
    void Update()
    {
        if (enter == true && Input.GetKeyDown(KeyCode.F))
        {
            if(Red.activeInHierarchy)
            {
                Pink.SetActive(false);
            }
            if(Green.activeInHierarchy)
            {
                Blue.SetActive(false);
            }
            Red.SetActive(!Red.activeInHierarchy && !Green.activeInHierarchy && !Blue.activeInHierarchy);
            Blue.SetActive(!Blue.activeInHierarchy && !Pink.activeInHierarchy && !Red.activeInHierarchy);
            Green.SetActive(!Green.activeInHierarchy && !Red.activeInHierarchy);
            Pink.SetActive(!Pink.activeInHierarchy && !Blue.activeInHierarchy);
            anim.Play("Light Switch");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Light Switch"))
        {
            enter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Light Switch"))
        {
            enter = false;
        }
    }

}