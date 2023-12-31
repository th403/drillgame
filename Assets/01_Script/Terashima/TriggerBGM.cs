using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBGM : MonoBehaviour
{
    public AudioSource as_MainGame1;
    public AudioSource as_MainGame2;
    public AudioSource as_MainGame3;
    public AudioSource as_MainGame4;
    public AudioSource as_Result;
    public AudioSource as_ResultLoop;
    public AudioClip ResultLoopClip;

    private bool isAudioEnd;

    // Start is called before the first frame update
    void Start()
    {
    }

    void MuteVolume(AudioSource audioSource)
    {
        audioSource.volume = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            as_Result.Play();
            isAudioEnd = true;

            MuteVolume(as_MainGame1);
            MuteVolume(as_MainGame2);
            MuteVolume(as_MainGame3);
            MuteVolume(as_MainGame4);

        }
    }

    public void Update()
    {
        if (!as_Result.isPlaying && isAudioEnd)
        {

            //audioSourceBGM2.loop = true;
            as_ResultLoop.Play();
            isAudioEnd = false;
            Debug.Log("aaa");

        }


    }
}
