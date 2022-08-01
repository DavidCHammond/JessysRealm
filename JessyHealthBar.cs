using UnityEngine;
using System.Collections;

public class JessyHealthBar : MonoBehaviour
{
    public Animator anim;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSprite();
    }

    void ChangeSprite()
    {
        if (PlayerMovement.currentHealth <= 100)
        {
            anim.SetBool("full", true);
            anim.SetBool("three", false);
            anim.SetBool("two", false);
            anim.SetBool("one", false);
            anim.SetBool("none", false);
        }
        if(PlayerMovement.currentHealth <= 75)
        {
            anim.SetBool("full", false);
            anim.SetBool("three", true);
            anim.SetBool("two", false);
            anim.SetBool("one", false);
            anim.SetBool("none", false);
        }
        if(PlayerMovement.currentHealth <= 50)
        {
            anim.SetBool("full", false);
            anim.SetBool("three", false);
            anim.SetBool("two", true);
            anim.SetBool("one", false);
            anim.SetBool("none", false);
        }
        if(PlayerMovement.currentHealth <= 25)
        {
            anim.SetBool("full", false);
            anim.SetBool("three", false);
            anim.SetBool("two", false);
            anim.SetBool("one", true);
            anim.SetBool("none", false);
        }
        if(PlayerMovement.currentHealth <= 0)
        {
            anim.SetBool("full", false);
            anim.SetBool("three", false);
            anim.SetBool("two", false);
            anim.SetBool("one", false);
            anim.SetBool("none", true);
        }
    }
}
