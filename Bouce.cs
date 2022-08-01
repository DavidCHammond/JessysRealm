using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouce : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Bounce());
        }
    }
    public IEnumerator Bounce()
    {
        anim.Play("Bounce");
        yield return new WaitForSeconds(.0001f);
        PlayerMovement.bounce = true;
        yield return new WaitForSeconds(.6f);
        PlayerMovement.bounce = false;
    }
}
