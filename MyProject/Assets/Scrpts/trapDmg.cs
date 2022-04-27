using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapDmg : MonoBehaviour
{
    GameObject Obj;
    public PlayerHealth player;
    // Start is called before the first frame update
    void Start()
    {
       Obj = GameObject.Find("PlayerHealth");
       player = Obj.GetComponent<PlayerHealth>();
    }

    void OnTriggerStay(Collider obj)
    {

        if (obj.gameObject.tag == "Player")
        {
            player.LowerHp();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
