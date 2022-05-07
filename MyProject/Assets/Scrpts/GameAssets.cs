using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets instance = new GameAssets();

    private GameAssets() { }

    public static GameAssets Instance
    {
        get
        {
            return instance;
        }
    }

    
    public float sysVolume;
    public bool music;
    public GameObject OMainTheme;

    public GameObject Ojump;
    private AudioSource MainTheme;
    private AudioSource jump;

    /*
    public int soundSize;
    public AudioClip[] Sounds;

    /*
    public GameObject playerAttck;

    public AudioClip[] soundAudioClipArray;
    public SoundAudioClip audioArray;
    /*
    [System.Serializable]
    public class SoundAudioClip {
        public SoundManager.Sound sound;
        public SoundAudioClip audioClip;
    }*/

    void updateVolume() {
        if (music) {
            MainTheme.volume = (sysVolume / 10);
            jump.volume = (sysVolume / 10);
        }
        else
        {
            MainTheme.volume = 0.0f;
            jump.volume = 0.0f;
        }
    }



    public void PlayJump()
    {
        jump.Play();
    }


    //void OnEnable()

    void OnSceneLoaded()
    {
        GameObject Obj = Instantiate(OMainTheme, new Vector3(0, 0, 0), Quaternion.identity);
        MainTheme = Obj.GetComponent<AudioSource>();
        Obj = Instantiate(Ojump, new Vector3(0, 0, 0), Quaternion.identity);
        jump = Obj.GetComponent<AudioSource>();

    }
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

        GameObject Obj = Instantiate(OMainTheme, new Vector3(0, 0, 0), Quaternion.identity);
        MainTheme = Obj.GetComponent<AudioSource>();
        Obj = Instantiate(Ojump, new Vector3(0, 0, 0), Quaternion.identity);
        jump = Obj.GetComponent<AudioSource>();


        //MainTheme = OMainTheme.GetComponent<AudioSource>();
        //jump = Ojump.GetComponent<AudioSource>();

        sysVolume = 5;

        //DontDestroyOnLoad(this);
        //soundSize = 3;
        //Sounds = new AudioClip[soundSize];
    }


    // Update is called once per frame
    void Update()
    {
        updateVolume();
        //Debug.Log("Sound:" + sysVolume);

    }
}
