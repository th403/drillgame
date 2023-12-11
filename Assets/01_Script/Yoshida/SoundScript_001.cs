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

    void Start()
    {
        audioMixer.GetFloat("BGM_Volume", out float bgmVolume);
        bGMSlider.value = bgmVolume;
        audioMixer.GetFloat("SE_Volume", out float seVolume);
        sESlider.value = seVolume;

        
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