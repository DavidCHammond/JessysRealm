using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEWprojectile : MonoBehaviour
{
    private Animator anim;
    private bool playerHit;

    public Vector3 target;
    public LayerMask enemyLayers;
    public LayerMask playerLayers;
    public LayerMask spearLayers;
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
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        PlayerHit();
    }
    public void PlayerHit()
    {
        Collider2D[] playerHit = Physics2D.OverlapCircleAll(projectileBox.position, projectileReach, playerLayers);

        foreach (Collider2D player in playerHit)
        {
            player.GetComponent<PlayerMovement>().Damage(projectileDamage);
            StartCoroutine(BreakDelay());
        }
        Collider2D[] spearHit = Physics2D.OverlapCircleAll(projectileBox.position, projectileReach, spearLayers);
        foreach (Collider2D spear in spearHit)
        {
            StartCoroutine(BreakDelay());
        }
    }
    public IEnumerator BreakDelay()
    {
        projectileReach = 0;
        projectileDamage = 0;
        anim.Play("Break");
        yield return new WaitForSeconds(.15f);
        Destroy(gameObject);
        Debug.Log("GOT HIT, HEALTH IS " + PlayerMovement.currentHealth);
    }
}
