using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public GameObject doggo;
    public float rotSpeed = 90; //rotation speed in degrees/second 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("1KEY")){
            doggo.GetComponent<Animator>().Play("RunForwardBattle");
        }
        else{
            doggo.GetComponent<Animator>().Play("Idle_Battle");
        }
    }
}
