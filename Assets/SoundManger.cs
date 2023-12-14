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
    public AudioSource HitGroundSE;
    public AudioSource SetPipeSE;
    public AudioSource UISelectSE;
    public AudioSource UICancelSE;
    public AudioSource LavaDropSE;

    public float SetPipeDelay = 1.0f;
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
    public void PlaySEHitGroundSE()
    {
        HitGroundSE.Play();
    }

    public void PlaySESetPipe()
    {
        Invoke("pPlaySESetPipe", SetPipeDelay);
    }
    private void pPlaySESetPipe()
    {
        SetPipeSE.Play();
    }
    public void PlaySEUISelect()
    {
        UISelectSE.Play();
    }
    public void PlaySEUICancel()
    {
        UICancelSE.Play();
    }

    public void PlaySELavaDrop()
    {
        LavaDropSE.Play();
    }

}
