using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Director : MonoBehaviour
{

    private static Director instance = new Director();

    private Director() { }
    public static Director Instance
    {
        get
        {
            return instance;
        }
    }

    private int currentLevel;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 1;
    }

    public void GoToMain() {
        SceneManager.LoadScene(0);
    }

    public void GoToCurrentLevel() {
        SceneManager.LoadScene(currentLevel);
    }

    public void GoToNext() {
        currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(currentLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
