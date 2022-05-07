using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject ODirector;
    private Director Director;

    public void PlayGame() 
    {
        Director.GoToNext();
    }

    public void QuitGame()
    {
        Debug.Log("I QUIT");
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        Director = ODirector.GetComponent<Director>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
