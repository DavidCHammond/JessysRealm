using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JessyTeleport : MonoBehaviour
{
    public float speed = 10f;
    public int levelSelect;
    public Vector3 startPos;
    public Vector3 portal1;
    public Vector3 portal2;
    public Vector3 portal3;
    public Vector3 portal4;
    public Vector3 portal5;
    public Vector3 portal6;
    public Vector3 portal7;
    public Vector3 portal8;
    public Vector3 portal9;
    public Vector3 portal10;
    public Vector3 portal11;
    public Vector3 portal12;
    private Vector3 current;

    public static bool willWalk;

    private void FixedUpdate()
    {
        if (Portal.teleport)
        {
            willWalk = true;
            if (Walk2Center.isCenter)
            {
                willWalk = false;
                float step = speed * Time.deltaTime;

                if (transform.position == startPos)
                {
                    current = portal1;
                }
                else if (transform.position == portal1)
                {
                    current = portal2;
                }
                else if (transform.position == portal2)
                {
                    current = portal3;
                }
                else if (transform.position == portal3)
                {
                    current = portal4;
                }
                else if (transform.position == portal4)
                {
                    current = portal5;
                }
                else if (transform.position == portal5)
                {
                    current = portal6;
                }
                else if (transform.position == portal6)
                {
                    current = portal7;
                }
                else if (transform.position == portal7)
                {
                    current = portal8;
                }
                else if (transform.position == portal8)
                {
                    current = portal9;
                }
                else if (transform.position == portal9)
                {
                    current = portal10;
                }
                else if (transform.position == portal10)
                {
                    current = portal11;
                }
                else if (transform.position == portal11)
                {
                    current = portal12;
                }
                if (transform.position == portal12)
                {
                    StartCoroutine(Delay());
                }
                transform.position = Vector3.MoveTowards(transform.position, current, step);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = this.transform;
            PlayerMovement.MoveIsEnabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = null;
            PlayerMovement.MoveIsEnabled = true;
        }
    }
    public IEnumerator Delay()
    {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(levelSelect);
    }
}
