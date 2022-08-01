using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker_Bug_Movement : MonoBehaviour
{
    public Vector3 start;
    public Vector3 end;
    public Vector3 current;
    public float speed;
    private Animator anim;
    private bool canMove;
    public GameObject knockBackBox;
    public Transform player;
    public Transform enemyBox;
    public float enemyReach = .4f;
    public int enemyDamage = 25;
    public LayerMask enemyLayers;
    public LayerMask playerLayers;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHit();
        float step = speed * Time.deltaTime;
        if (transform.position == start && canMove)
        {
            current = end;
            anim.SetTrigger("WalkLeft");
        }
        else if (transform.position == end && canMove)
        {
            current = start;
            anim.SetTrigger("WalkRight");
        }
        else if (!canMove)
        {
            current = transform.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, current, step);
        if (BugHead.health <= 0)
        {
            canMove = false;
            StartCoroutine(Death());
        }
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
    public IEnumerator Death()
    {
            PlayerMovement.bounce = true;
            anim.SetBool("Dead", true);
            yield return new WaitForSeconds(.001f);
            PlayerMovement.bounce = false;
            yield return new WaitForSeconds(.2f);
            Destroy(gameObject);
    }
    public IEnumerator Delay()
    {
        Debug.Log("GOT HIT, HEALTH IS " + PlayerMovement.currentHealth);
        enemyReach = 0;
        enemyDamage = 0;
        StartCoroutine(KnockBack());
        yield return new WaitForSeconds(1f);
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
