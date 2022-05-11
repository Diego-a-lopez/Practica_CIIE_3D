using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHP; //the player max health, this should be assigned 5 aprox
    public int currentHP;
    public float safeTime; //a little cooldown for the player to be invulnerable, as the collision damage act really fast
    private float safeTimeCounter; //safe time left
    private bool isSafe;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP; //player starts full health
        isSafe = false; //player starts vulnerable to damage
        safeTimeCounter = safeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP <= 0) {
            gameObject.SetActive(false); //this code is temporal, when the player dies is desactivated
        }

        if (isSafe) {
            safeTimeCounter -= Time.deltaTime;
            if (safeTimeCounter < 0) {
                isSafe = false;
                safeTimeCounter = safeTime;
            } 
        }
    }

    //this function is called by the enemies when player collides with them
    public void HurtPlayer(int damage) { //damage is the damage dealt, normally 1
        if (!isSafe) {
            currentHP -= damage;
            isSafe = true;
        }

    }
}
