using UnityEngine;
using System.Collections;

public class BossHealthBar : MonoBehaviour
{
    public Animator anim;
    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        ChangeSprite();
    }

    void ChangeSprite()
    {
        if (Enemy.currentHealth <= 200)
        {
            anim.SetBool("full", true);
            anim.SetBool("seven", false);
            anim.SetBool("six", false);
            anim.SetBool("five", false);
            anim.SetBool("four", false);
            anim.SetBool("three", false);
            anim.SetBool("two", false);
            anim.SetBool("one", false);
            anim.SetBool("none", false);
        }
        if (Enemy.currentHealth <= 175)
        {
            anim.SetBool("full", false);
            anim.SetBool("seven", true);
            anim.SetBool("six", false);
            anim.SetBool("five", false);
            anim.SetBool("four", false);
            anim.SetBool("three", false);
            anim.SetBool("two", false);
            anim.SetBool("one", false);
            anim.SetBool("none", false);
        }
        if (Enemy.currentHealth <= 150)
        {
            anim.SetBool("full", false);
            anim.SetBool("seven", false);
            anim.SetBool("six", true);
            anim.SetBool("five", false);
            anim.SetBool("four", false);
            anim.SetBool("three", false);
            anim.SetBool("two", false);
            anim.SetBool("one", false);
            anim.SetBool("none", false);
        }
        if (Enemy.currentHealth <= 125)
        {
            anim.SetBool("full", false);
            anim.SetBool("seven", false);
            anim.SetBool("six", false);
            anim.SetBool("five", true);
            anim.SetBool("four", false);
            anim.SetBool("three", false);
            anim.SetBool("two", false);
            anim.SetBool("one", false);
            anim.SetBool("none", false);
        }
        if (Enemy.currentHealth <= 100)
        {
            anim.SetBool("full", false);
            anim.SetBool("seven", false);
            anim.SetBool("six", false);
            anim.SetBool("five", false);
            anim.SetBool("four", true);
            anim.SetBool("three", false);
            anim.SetBool("two", false);
            anim.SetBool("one", false);
            anim.SetBool("none", false);
        }
        if (Enemy.currentHealth <= 75)
        {
            anim.SetBool("full", false);
            anim.SetBool("seven", false);
            anim.SetBool("six", false);
            anim.SetBool("five", false);
            anim.SetBool("four", false);
            anim.SetBool("three", true);
            anim.SetBool("two", false);
            anim.SetBool("one", false);
            anim.SetBool("none", false);
        }
        if (Enemy.currentHealth <= 50)
        {
            anim.SetBool("full", false);
            anim.SetBool("seven", false);
            anim.SetBool("six", false);
            anim.SetBool("five", false);
            anim.SetBool("four", false);
            anim.SetBool("three", false);
            anim.SetBool("two", true);
            anim.SetBool("one", false);
            anim.SetBool("none", false);
        }
        if (Enemy.currentHealth <= 25)
        {
            anim.SetBool("full", false);
            anim.SetBool("seven", false);
            anim.SetBool("six", false);
            anim.SetBool("five", false);
            anim.SetBool("four", false);
            anim.SetBool("three", false);
            anim.SetBool("two", false);
            anim.SetBool("one", true);
            anim.SetBool("none", false);
        }
        if (Enemy.currentHealth <= 0)
        {
            anim.SetBool("full", false);
            anim.SetBool("seven", false);
            anim.SetBool("six", false);
            anim.SetBool("five", false);
            anim.SetBool("four", false);
            anim.SetBool("three", false);
            anim.SetBool("two", false);
            anim.SetBool("one", false);
            anim.SetBool("none", true);
        }
    }
}
