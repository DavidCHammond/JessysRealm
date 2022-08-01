using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerBugAttack : MonoBehaviour
{
    public Transform player;
    public Transform enemyBox;
    public float enemyReach = .4f;
    public int enemyDamage = 25;
    public GameObject knockBackBox;
    public LayerMask enemyLayers;
    public LayerMask playerLayers;
    public float speed;

    void Update()
    {
        PlayerHit();
    }
    public void PlayerHit()
    {
        Collider2D[] playerHit = Physics2D.OverlapCircleAll(enemyBox.position, enemyReach, playerLayers);

        foreach (Collider2D player in playerHit)
        {
            player.GetComponent<PlayerMovement>().Damage(enemyDamage);
            StartCoroutine(Delay());
        }
    }
    public IEnumerator Delay()
    {
        enemyReach = 0;
        enemyDamage = 0;
        StartCoroutine(KnockBack());
        yield return new WaitForSeconds(1f);
        Debug.Log("GOT HIT, HEALTH IS " + PlayerMovement.currentHealth);
        enemyReach = .5f;
        enemyDamage = 25;
    }
    public IEnumerator KnockBack()
    {
        knockBackBox.SetActive(true);
        yield return new WaitForSeconds(.5f);
        knockBackBox.SetActive(false);
    }
}
