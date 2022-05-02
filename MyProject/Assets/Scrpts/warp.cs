using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp : MonoBehaviour
{


    GameObject Obj;
    private Director director;

    void OnTriggerEnter(Collider obj)
    {

        if (obj.gameObject.tag == "Player")
        {
            NextGame();
        }

    }


    public void NextGame()
    {
        director.GoToNext();
    }

    // Start is called before the first frame update
    void Start()
    {
        Obj = GameObject.Find("Director");
        director = Obj.GetComponent<Director>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
