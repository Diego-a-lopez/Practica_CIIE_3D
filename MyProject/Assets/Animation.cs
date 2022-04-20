using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public GameObject doggo;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            doggo.GetComponent<Animator>().Play("RunForwardBattle");
        }
        else if (Input.GetButton("Jump"))
        {
            doggo.GetComponent<Animator>().Play("Defend");
        }
        else
        {
            doggo.GetComponent<Animator>().Play("Idle_Battle");
        }
    }
}