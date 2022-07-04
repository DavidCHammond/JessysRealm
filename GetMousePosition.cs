using UnityEngine;
using System.Collections;

public class GetMousePosition : MonoBehaviour
{
    private Vector2 current;
    public GameObject jessy;
    public static bool q1;
    public static bool q2;
    public static bool q3;
    public static bool q4;

    // Update is called once per frame
    private void Start()
    {
    
    }
    void Update()
    {
        current = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(Input.mousePosition);
        transform.position = current;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Q1"))
        {
            q1 = true;
            q2 = false;
            q3 = false;
            q4 = false;
        }
        if (collision.CompareTag("Q2"))
        {
            q2 = true;
            q1 = false;
            q3 = false;
            q4 = false;
        }
        if (collision.CompareTag("Q3"))
        {
            q3 = true;
            q2 = false;
            q1 = false;
            q4 = false;
        }
        if (collision.CompareTag("Q4"))
        {
            q4 = true;
            q2 = false;
            q3 = false;
            q1 = false;
        }
    }
}
