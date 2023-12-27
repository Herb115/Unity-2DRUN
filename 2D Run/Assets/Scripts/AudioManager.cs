using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    //播放器
    //音乐播放器
    public AudioSource MusicPlayer;
    //音效播放器
    public AudioSource SoundPlayer;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    //播放音乐
    public void PlayMusic(string name)
    {
        if(MusicPlayer.isPlaying == false)
        {
            AudioClip clip = Resources.Load<AudioClip>(name);
            MusicPlayer.clip=clip;
            MusicPlayer.Play();
        }
    }

    //停止播放
    public void StopMusic()
    {
        MusicPlayer.Stop();
    }
    //播放音效
    public void PlaySound(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>(name);
        SoundPlayer.PlayOneShot(clip);
    }
}
