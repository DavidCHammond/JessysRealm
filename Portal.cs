using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public float speed = 10.0f;
    public float speed1 = .5f;

    public int levelSelect;

    public Vector3 startPosition;
    public Vector3 target1;
    private Vector3 current;
    public GameObject Jessy;

    public static bool teleport;

    // Update is called once per frame
    private void Start()
    {
        teleport = false;
    }
    void FixedUpdate()
    {
        if (Eye.portal2menu)
        {
            float step = speed * Time.deltaTime;
            if (transform.position == startPosition)
            {
                current = target1;
            }
            transform.position = Vector3.MoveTowards(transform.position, current, step);
            float step1 = speed1 * Time.deltaTime;
            if (transform.position == target1)
            {
                GetComponent<Animator>().SetBool("Portal", true);
                teleport = true;
            }
        }
    }
}
