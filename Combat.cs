using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Animator anim;

    public Transform leftpunchBox;
    public Transform rightpunchBox;
    public LayerMask enemyLayers;

    public float punchReach = 0.5f;
    public int punchDamage = 40;

    public float punchRate = 2f;
    float nextPunch = 0f;

    public static bool IsInputEnabled = true;

    public void Update()
    {
        if(IsInputEnabled)
        {
            if (Time.time >= nextPunch)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    RightPunch();
                    nextPunch = Time.time + 1f / punchRate;
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    LeftPunch();
                    nextPunch = Time.time + 1f / punchRate;
                }
            }
        }
    }
    void RightPunch()
    {
        anim.SetTrigger("Rpunch");

        Collider2D[] enemiesPunched = Physics2D.OverlapCircleAll(rightpunchBox.position, punchReach, enemyLayers);

        foreach (Collider2D enemy in enemiesPunched)
        {
            enemy.GetComponent<Enemy>().RightSideDamage(punchDamage);
            Debug.Log(enemy.name + "GOT PUNCHED");
        }
    }
    void LeftPunch()
    {
        anim.SetTrigger("Lpunch");

        Collider2D[] enemiesPunched = Physics2D.OverlapCircleAll(leftpunchBox.position, punchReach, enemyLayers);

        foreach (Collider2D enemy in enemiesPunched)
        {
            enemy.GetComponent<Enemy>().LeftSideDamage(punchDamage);
            Debug.Log(enemy.name + "GOT PUNCHED");
        }
    }
}