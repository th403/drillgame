using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundScript_001 : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider bGMSlider;
    public Slider sESlider;

    public AudioClip audioClip1;
    public AudioClip audioClip2;
    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private bool isAudioEnd;


    void Start()
    {
        audioMixer.GetFloat("BGM_Volume", out float bgmVolume);
        bGMSlider.value = bgmVolume;
        audioMixer.GetFloat("SE_Volume", out float seVolume);
        sESlider.value = seVolume;

        audioSource1 = gameObject.GetComponent<AudioSource>();
        audioSource2 = gameObject.GetComponent<AudioSource>();

        audioSource1.PlayOneShot(audioClip1);
        isAudioEnd = true;
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            //audioSource1.Stop();
            audioSource2.Stop();
            audioSource1.PlayOneShot(audioClip1);
            Debug.Log("bbb");


            //audioSource1.Stop(audioClip1);
            //audioSource2.Stop(audioClip2);
        }*/

        if (!audioSource1.isPlaying && isAudioEnd)
        {
            audioSource2.PlayOneShot(audioClip2);
            Debug.Log("aaa");

            //audioSource1.Stop(audioClip1);
            //audioSource2.Stop(audioClip2);

        }
    }


    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGM_Volume", volume);
    }

    public void SetSE(float volume)
    {
        audioMixer.SetFloat("SE_Volume", volume);
    }

}