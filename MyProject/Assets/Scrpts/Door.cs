using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour

{
    GameObject Obj;
    public Inventory inv;
    // Start is called before the first frame update
    void Start()
    {
        Obj = GameObject.Find("Inventory");
        inv = Obj.GetComponent<Inventory>();
    }

    void OnTriggerEnter(Collider obj)
    {

        if (obj.gameObject.tag == "Player") 
        {
            //inv.AddRedKey();
            if (inv.redKey) Destroy(this.gameObject);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
