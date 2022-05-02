using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager3 : MonoBehaviour
{
    public static SoundManager3 Instance;

    void Awake() {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
}
