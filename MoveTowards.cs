using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    private float speed = 10.0f;
    private Vector2 target;
    private Vector2 position;
    private Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(0.0f, 0.0f);
        position = gameObject.transform.position;

        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }
        void OnGUI()
    {
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();
        Vector2 point = new Vector2();

        // compute where the mouse is in world space
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;
        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0.0f));

        if (Input.GetMouseButtonDown(0))
        {
            // set the target to the mouse click location
            target = point;
        }
    }
}
