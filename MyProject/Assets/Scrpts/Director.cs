using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Director : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GoToMain() {
        SceneManager.LoadScene(0);
    }

    public void GoToNext() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
