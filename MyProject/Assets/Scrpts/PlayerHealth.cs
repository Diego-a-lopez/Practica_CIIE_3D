using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHP; //the player max health, this should be assigned 5 aprox
    public int currentHP;

    public GameObject director;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP; //player starts full health
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP <= 0) {
            //gameObject.SetActive(false); //this code is temporal, when the player dies is desactivated
            director.GetComponent<Director>().GoToMain();
        }
    }

    //this function is called by the enemies when player collides with them
    public void HurtPlayer(int damage) { //damage is the damage dealt, normally 1
        currentHP -= damage;

    }
}
