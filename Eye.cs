using UnityEngine;
using System.Collections;

public class Eye : MonoBehaviour
{
    public float speed = 10.0f;

    public GameObject boss;
    public Vector3 startPosition;
    public Vector3 target1;
    private Vector3 current;
    public static bool portal2menu;

    // Update is called once per frame
    void FixedUpdate()
    {
    portal2menu = false;
    if (boss == null)
    {
        float step = speed * Time.deltaTime;
        if (transform.position == startPosition)
        {
            current = target1;
        }
        transform.position = Vector3.MoveTowards(transform.position, current, step);
        if (transform.position == target1)
        {
            portal2menu = true;
        }
    }
}
}
