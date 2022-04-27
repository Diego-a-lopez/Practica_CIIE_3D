using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{

    public int maxHP = 100; //the player max health, this should be assigned 5 aprox
    public int currentHP;
    private Director director;

    GameObject Obj;
    public Player player;


    public void LowerHp()
    {
        currentHP += -10;
        //if (HP == 0) Destroy(this.gameObject);
    }

    public void IncreaseHp()
    {
        currentHP += 10;
    }



    // Start is called before the first frame update
    void Start()
    {
        maxHP = 100;
        currentHP = maxHP; //player starts full health
        Obj = GameObject.Find("Director");
        director = Obj.GetComponent<Director>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP <= 0) {
            //gameObject.SetActive(false); //this code is temporal, when the player dies is desactivated
            director.GoToMain(); 
        }
    }

    //this function is called by the enemies when player collides with them
    public void HurtPlayer(int damage) { //damage is the damage dealt, normally 1
        currentHP -= damage;

    }
}
