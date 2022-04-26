using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapDmg : MonoBehaviour
{
    GameObject Obj;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
       Obj = GameObject.Find("Player");

       player = Obj.GetComponent<Player>();
    }

    void OnTriggerEnter(Collider obj)
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
