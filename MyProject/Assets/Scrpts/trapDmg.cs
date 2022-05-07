using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapDmg : MonoBehaviour
{
    GameObject Obj;
    int cooldown;
    public PlayerHealth player;
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerStay(Collider obj)
    {

        if (obj.gameObject.tag == "Player")
        {
            if (cooldown < 0) { player.HurtPlayer(10); cooldown = 500; }
                
        }

    }

    // Update is called once per frame
    void Update()
    {
        cooldown = cooldown - 10;
    }
}
