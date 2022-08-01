using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public Transform boss;
    public Transform player;
    public GameObject projectile1;

    public float fireRate = 5000f;
    public float force = 20f;

    private float fireTime;

    // Start is called before the first frame update
    void Start()
    { 
     
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }
    private void Fire()
    {
        if(Time.time > fireTime)
        {
            fireTime = Time.time + fireRate / 1000;
            Vector2 playerPos = new Vector2(boss.position.x, boss.position.y);
            GameObject projectile2 = Instantiate(projectile1, playerPos, Quaternion.identity);
            Vector2 direction = playerPos - (Vector2)player.position;
            projectile2.GetComponent<Rigidbody2D>().velocity = direction * force;
        }
    }
}
