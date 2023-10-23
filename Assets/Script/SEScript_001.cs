using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SEScript_001 : MonoBehaviour
{
    public Slider slider;
    AudioSource audioSource;

    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        slider.onValueChanged.AddListener(value => this.audioSource.volume = value);
    }

    
}