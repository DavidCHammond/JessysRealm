using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectile1;
    public GameObject projectile2;

    public GameObject enemy;

    private float timeBTWshots1;
    private float timeBTWshots2;
    public float startTime1;
    public float startTime2;

    private bool willShoot;
    private bool isShooting;
    public static bool launch;
    public Animator anim;

    private float delay = 2f;
    public float tDelay;



    // Start is called before the first frame update
    void Start()
    {
        willShoot = false;
        timeBTWshots1 = startTime1;
        timeBTWshots2 = startTime2;
    }

    // Update is called once per frame
    void Update()
    {
        if (willShoot && !Enemy.isDead)
        {
            if (timeBTWshots1 <= 0 && timeBTWshots2 >= 0)
            {
                anim.SetTrigger("Launch");
                Instantiate(projectile1, transform.position, Quaternion.identity);
                timeBTWshots1 = startTime1;
                isShooting = true;
            }
            else
            {
                timeBTWshots1 -= Time.deltaTime;
                launch = true;
                isShooting = false;
            }
            if (timeBTWshots2 <= 0 && timeBTWshots1 >= 0)
            {
                anim.SetTrigger("Launch");
                Instantiate(projectile2, transform.position, Quaternion.identity);
                timeBTWshots2 = startTime2 + tDelay;
                isShooting = true;
            }
            else
            {
                timeBTWshots2 -= Time.deltaTime;
                launch = true;
                isShooting = false;
            }
        }
        if (Enemy.isDead)
        {
            Destroy(enemy, delay); 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            willShoot = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            willShoot = false;
        }
    }
}
