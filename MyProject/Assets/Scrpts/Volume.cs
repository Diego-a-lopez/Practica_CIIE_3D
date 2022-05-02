using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Text text;
    public GameObject OAudioClip;
    private AudioSource AudioClip;
    private Volume volume;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        AudioClip = OAudioClip.GetComponent<AudioSource>();
        volume = AudioClip.GetComponent<Volume>();
    }

    public void UpVolume()
    {
       


    }
    public void DownVolume()
    {
       


    }

    // Update is called once per frame
    void Update()
    {
        text = volume.text;
    }
}
