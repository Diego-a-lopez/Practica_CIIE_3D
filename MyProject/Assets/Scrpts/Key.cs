using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    GameObject Obj;
    public Inventory inv;
    // Start is called before the first frame update
    private float speed = 0.1f;
    private float rotationSpeed = 90;
    private Rigidbody rigidBody;
    Quaternion toRotation;
    int pos = 0;
    bool down = false;
    void Start()
    {
        Obj = GameObject.Find("Inventory");
        inv = Obj.GetComponent<Inventory>();
        rigidBody = GetComponent<Rigidbody>();
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

    void FixedUpdate() {
        if ((pos < 100) && !(down))
        {
            pos++;
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else if (pos > 0)
        {
            down = true;
            pos--;
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else down = false;
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
