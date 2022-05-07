using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    private Text text;
    public GameObject OAudioClip;
    public GameObject OGameAssets;
    private GameAssets GameAssets;
    //private AudioSource AudioClip;
    private float volume;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        OGameAssets = GameObject.Find("GameAssets");
        GameAssets = OGameAssets.GetComponent<GameAssets>();
        volume = GameAssets.sysVolume;
        //AudioClip = GameAssets.GetComponent<AudioSource>();
    }

    public void UpVolume()
    {

        if (volume < 10) {
            volume++;
            GameAssets.sysVolume = volume;
            //AudioClip.volume = (volume + 1) / 10; 
        }

    }
    public void DownVolume()
    {

        if (volume > 0)
        {
            volume--;
            GameAssets.sysVolume = volume;
            //AudioClip.volume = (volume - 1) / 10;
        
        }

    }

    public void ToggleSound() {
        if (GameAssets.music) GameAssets.music = false;
        else GameAssets.music = true;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = volume.ToString();
    }
}
