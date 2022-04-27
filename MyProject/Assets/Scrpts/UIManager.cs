using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Slider hpbar; //assign the object HPbar of the canvas
    public Text hptext; //assing the object HPnums
    public PlayerHealth playerHealth; //as the script is assigned to the dog, assign here the dog
    GameObject Obj;
    GameObject Obj2;
    //public PlayerInventory playerInventory; // as the script is assigned to the dog, assign here the dog

    private static bool uiExists; //this will keep the hp bar and text when the player changes to another scene, otherwise it'd dissapear in the new scene


    // Start is called before the first frame update
    void Start()
    {
        Obj = GameObject.Find("PlayerHealth");
        Obj2 = GameObject.Find("HP");
        playerHealth = Obj.GetComponent<PlayerHealth>();

        if (!uiExists) {
            uiExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else {
            Destroy(gameObject); //this will port or destroy the hp bar at scene change
        }
    }

    // Update is called once per frame
    void Update()
    {
        hpbar.maxValue = playerHealth.maxHP; //the bar's top value will be the maxHP of the player
        hpbar.value = playerHealth.currentHP; //bar will fill until the current hp of the player
        hptext.text = "HP: " + playerHealth.maxHP + "/" + playerHealth.currentHP; //text will show hp in format HP: x/5
    }
}
