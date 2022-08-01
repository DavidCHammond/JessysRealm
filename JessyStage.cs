using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JessyStage : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GetMousePosition.q1)
        {
            anim.StopPlayback();
            anim.Play("NE_Idle");
        }
        if (GetMousePosition.q2)
        {
            anim.StopPlayback();
            anim.Play("NW_Idle");
        }
        if (GetMousePosition.q3)
        {
            anim.StopPlayback();
            anim.Play("SW_Idle");
        }
        if (GetMousePosition.q4)
        {
            anim.StopPlayback();
            anim.Play("SE_Idle");
        }
    }
}
