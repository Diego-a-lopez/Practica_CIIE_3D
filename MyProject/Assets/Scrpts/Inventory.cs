using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool redKey;
    public bool greenKey;
    public bool blueKey;

    public void AddRedKey()
    {
        redKey = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        redKey = false;
        greenKey = false;
        blueKey = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
