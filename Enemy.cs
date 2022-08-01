using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public static bool isDead;
    public SpriteRenderer enemy;

    public int maxHealth = 100;
    public static int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        Respawn();
    }
    // Update is called once per frame
    public void LeftSideDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth > 0)
        {
            anim.SetTrigger("R_Punched");
        }
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    public void RightSideDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth > 0)
        {
            anim.SetTrigger("L_Punched");
        }
        if(currentHealth <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        Debug.Log("Enemy Has Been Destroyed");

        anim.SetTrigger("IsDead");

        isDead = true;


        // GetComponent<Collider2D>().enabled = false;
        // this.enabled = false;
    }
    void Respawn()
    {
        if (PlayerMovement.hasDied)
        {
            currentHealth = maxHealth;
            Debug.Log("Enemy has regenerated.");
        }
    }
}
