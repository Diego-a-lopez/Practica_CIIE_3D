using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour
{
    private  static Singleton _instance = new Singleton();

    private Singleton()
    {
    }

    public static Singleton Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
}