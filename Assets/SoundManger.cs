using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour
{
    private static SoundManger instance;

    private void Awake()
    {
        instance = this;
    }

    public static SoundManger Instance
    {
        get { return instance; }
    }

    public AudioSource RockDestroySE;
    public AudioSource DrillerDestroySE;
    public AudioSource GetMoneySE;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySERockDestroy()
    {
        RockDestroySE.pitch = Random.Range(0.33f,1.67f);
        RockDestroySE.Play();
    }
    public void PlaySEDrillerDestroy()
    {
        DrillerDestroySE.Play();
    }
    public void PlaySEGetMoneySE()
    {
        GetMoneySE.Play();
    }

}
