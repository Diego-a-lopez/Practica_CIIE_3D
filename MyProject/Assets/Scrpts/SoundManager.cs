using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SoundManager
{
    public enum Sound { 
        PlayerMove,
        PlayerWarp,
        EnemyHit,
        EnemyDie,
        Treasure,
    }
    
    /*
    private static Dictionary<Sound, float> soundTimerDictionary;
    
    public static void Initialize() {
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.PlayerMove] = 0f;
    }

    public static void PlaySound(Sound sound)
    {
        if (canPlaySound(sound)) {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.addComponent<AudioSource>();
            audioSource.PlayOneShot(GetAudioClip(sound));
        }
    }

    private static bool canPlaySound(Sound sound) {
        switch (sound) {
            default:
                return true;
            case Sound.PlayerMove:
                if (soundTimerDictionary.ContainsKey(sound)) {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float playerMoveTimerMax = 0.5f;
                    if (lastTimePlayed + playerMoveTimerMax < Time.time) {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else return false;
                }
                //break;
        }
    }

    private static AudioClip GetAudioClip(Sound sound) {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray) {
            if (soundAudioClip.sound == sound) {
                return soundAudioClip.audioClip;
            }
        }
        Debug.logError("Sound" + sound + "not found"); 
        return null;
    }*/
}
