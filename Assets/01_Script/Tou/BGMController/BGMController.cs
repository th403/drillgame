using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    private static BGMController instance;

    private void Awake()
    {
        instance = this;
    }

    public static BGMController Instance
    {
        get { return instance; }
    }


    [Header("attach")]
    public AudioSource as_MainGame;
    public AudioSource as_Result;

    [Header("read only")]
    public AudioSource currentAudioSource;

    public void PlayMainGameBGM()
    {
        ChangeAndPlay(as_MainGame);
    }

    public void PlayResultBGM()
    {
        ChangeAndPlay(as_Result);
    }

    void ChangeAndPlay(AudioSource audioS)
    {
        if(currentAudioSource) currentAudioSource.Stop();
        currentAudioSource = audioS;
        currentAudioSource.Play();
    }
}
