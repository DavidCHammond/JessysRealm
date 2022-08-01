using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;
    public SpriteRenderer player;
    public int jessyLives = JessyLives.jessyLives;

    public Transform Spawn;

    public int maxHealth = 100;
    public static int currentHealth;

    public float speed = 5f;
    public float jumpSpeed = 8f;

    public float jumpRate = 2f;
    float nextJump = 0f;

    public float platformRadius;
    public Transform platformCheck;
    public LayerMask platformLayer;

    public Transform leftpunchBox;
    public Transform rightpunchBox;
    public Transform box;
    public LayerMask enemyLayers;
    public LayerMask bugLayers;

    public float squishReach = .5f;
    public float punchReach = 0.5f;
    public int punchDamage = 40;

    public float punchRate = 2f;
    public float deathRate = 6f;
    float nextPunch = 0f;
    float nextDeath = 0f;

    private int lifeLoss = 1;

    //public int currentScene;

    private bool grounded;
    public static bool isPunching;
    public static bool IsInputEnabled = true;
    public static bool MoveIsEnabled = true;
    public static bool isJumping = false;
    public static bool rPunch;
    public static bool lPunch;
    public static bool resetScene;
    public static bool hasDied;
    public static bool hasRespawned;
    public static bool bounce;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        hasDied = false;
    }


    void Update()
    {
        grounded = Physics2D.OverlapCircle(platformCheck.position, platformRadius, platformLayer);
        if (IsInputEnabled)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");

            if (Time.time >= nextPunch)
            {
                MoveIsEnabled = true;
                if (Input.GetKeyDown(KeyCode.D))
                {
                    MoveIsEnabled = false;
                    RightPunch();
                    nextPunch = Time.time + 1f / punchRate;
                    rPunch = true;
                }
                if (!Input.GetKeyDown(KeyCode.D))
                {
                    isPunching = false;
                    rPunch = false;
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    MoveIsEnabled = false;
                    LeftPunch();
                    nextPunch = Time.time + 1f / punchRate;
                    lPunch = true;
                }
                if (!Input.GetKeyDown(KeyCode.A))
                {
                    isPunching = false;
                    lPunch = false;
                }
            }
            if (MoveIsEnabled && !isPunching)
            {
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
                    anim.Play("R_Walk");
                }
                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
                    anim.Play("L_Walk");
                }
            }

            if (Input.GetButtonDown("Jump") && grounded && Time.time >= nextJump && MoveIsEnabled)
            {
                nextJump = Time.time + 1f / jumpRate;
                Debug.Log(gameObject + "can jump");
                body.velocity = new Vector2(body.velocity.x, jumpSpeed);
                isJumping = true;
            }
            if(Input.GetButtonUp("Jump"))
            {
                isJumping = false;
            }
            else if (bounce == true)
            {
                body.velocity = new Vector2((body.velocity.x*2)*(body.velocity.y*0), 6);
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
                    anim.Play("R_Walk");
                }
                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
                    anim.Play("L_Walk");
                }
            }
        }
        if (hasDied && IsInputEnabled)
        {
            StartCoroutine(RespawnDelay());
        }
        Squish();
    }
    void RightPunch()
    {
        isPunching = true;

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
        isPunching = true;

        anim.SetTrigger("Lpunch");

        Collider2D[] enemiesPunched = Physics2D.OverlapCircleAll(leftpunchBox.position, punchReach, enemyLayers);

        foreach (Collider2D enemy in enemiesPunched)
        {
            enemy.GetComponent<Enemy>().LeftSideDamage(punchDamage);
            Debug.Log(enemy.name + "GOT PUNCHED");
        }
    }
    void Squish()
    {
        Collider2D[] bugSquished = Physics2D.OverlapCircleAll(box.position, squishReach, bugLayers);

        foreach (Collider2D enemy in bugSquished)
        {
            //enemy.GetComponent<BugHead>().health=-100;
            Debug.Log(enemy.name + "has been squished");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lava"))
        {
            hasDied = true;
            Debug.Log("Respawned");
        }
        if (other.CompareTag("Spawn"))
        {
            currentHealth = maxHealth;
            Debug.Log("Health is " + currentHealth);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Deadzone"))
        {
            hasDied = false;
            Debug.Log("nope");
        }
    }
        public IEnumerator FlashRed()
    {
        player.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        player.color = Color.white;

    }
    public IEnumerator RespawnDelay()
    {
        IsInputEnabled = false;
        Death();
        yield return new WaitForSeconds(.3f);
        transform.position = Spawn.position;
        Life();
        yield return new WaitForSeconds(.25f);
        IsInputEnabled = true;
        hasDied = false;
    }
    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
    }
    public void Damage(int damage)
    {
        currentHealth -= damage*1;
        if (currentHealth > 0)
        {
            StartCoroutine(FlashRed());
        }
        else if (currentHealth < 1)
        {
            hasDied = true;
        }
    }
    private void Life()
    {
        JessyLives.jessyLives -= lifeLoss;
    }
    public void Death()
    {
        Debug.Log("Jessy's Health is " + currentHealth + "Jessy Has Been Knocked Out");

        anim.SetTrigger("IsDead");


        return;
    } 
}