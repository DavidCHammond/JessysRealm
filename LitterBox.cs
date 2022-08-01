using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitterBox : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    public void DamageTaken(int damage)
    {

        anim.SetTrigger("Enter");

        {
            Death();
        }
    }
    void Death()
    {
        Debug.Log("Enemy Has Been Destroyed");

        anim.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
