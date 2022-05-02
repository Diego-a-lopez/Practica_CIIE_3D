using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {

            if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i;

        }
    }/*
    public int sysVolume;
    public bool music;
    public SoundAudioClip audioArray;
    /*
    [System.Serializable]
    public class SoundAudioClip {
        public SoundManager.Sound sound;
        public SoundAudioClip audioClip;
    }
        /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
