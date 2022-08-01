using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEWpunchableprojectile : MonoBehaviour
{
    private Animator anim;
    private bool wasHit;

    public Vector3 target;
    public Vector3 boss;
    public Vector3 peak;
    private Vector3 current;

    public LayerMask enemyLayers;
    public LayerMask playerLayers;
    public LayerMask spearLayers;
    public LayerMask punchLayers;
    public Transform projectileBox;
    public float projectileReach;


    public float speed;
    public int projectileDamage = 25;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        BallPunched();
        Spear();
        if (!wasHit)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            transform.eulerAngles = Vector3.forward * 50;
            PlayerHit();
        }
        if (wasHit)
        {
            transform.position = Vector3.MoveTowards(transform.position, peak, speed * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, boss, speed * Time.deltaTime * 2);

        }
        if (transform.position == boss)
        {
            EnemyHit();
            wasHit = false;

        }
    }
    public void PlayerHit()
    {
        Collider2D[] playerHit = Physics2D.OverlapCircleAll(projectileBox.position, projectileReach, playerLayers);

        foreach (Collider2D player in playerHit)
        {
            player.GetComponent<PlayerMovement>().Damage(projectileDamage);
            StartCoroutine(BreakDelay());
            Debug.Log("JESSY GOT HIT, HEALTH IS " + PlayerMovement.currentHealth);
        }
    }
    public void Spear()
    {
        Collider2D[] spearHit = Physics2D.OverlapCircleAll(projectileBox.position, projectileReach, spearLayers);
        foreach (Collider2D spear in spearHit)
        {
            StartCoroutine(BreakDelay());
        }
    }
    public void EnemyHit()
    { 
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(projectileBox.position, projectileReach, enemyLayers);
        foreach (Collider2D enemy in enemyHit)
        {
            enemy.GetComponent<Enemy>().RightSideDamage(projectileDamage);
            Debug.Log(enemy.name + "GOT HIT, HEALTH IS " + Enemy.currentHealth);
            StartCoroutine(BreakDelay());
        }    

    }
    public void BallPunched()
    {
        Collider2D[] ballPunched = Physics2D.OverlapCircleAll(projectileBox.position, projectileReach, punchLayers);
        foreach(Collider2D ball in ballPunched)
        {
            if (PlayerMovement.rPunch)
            { 
                wasHit = true;
            }
            else
            {
                wasHit = false;
            }
        }
    }
    public IEnumerator BreakDelay()
    {
        projectileReach = 0;
        projectileDamage = 0;
        anim.Play("Break1");
        yield return new WaitForSeconds(.15f);
        Destroy(gameObject);
    }
}
