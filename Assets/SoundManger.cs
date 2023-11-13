using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour
{
    public AudioSource DestroySE;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySEDestroy()
    {
        DestroySE.pitch = Random.Range(0.33f,1.67f);
        DestroySE.Play();
    }

}
