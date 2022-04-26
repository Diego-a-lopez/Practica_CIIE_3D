using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    GameObject Obj;
    public Inventory inv;
    // Start is called before the first frame update
    void Start()
    {
        Obj = GameObject.Find("Inventory");
        inv = Obj.GetComponent<Inventory>();
    }

    void OnTriggerEnter (Collider obj)
    {

        if (obj.gameObject.tag == "Player") {
            inv.AddRedKey();
            Destroy(this.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
