using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CrossFadeTest : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioMixerSnapshot[] snapshots;
    float[] weights = new float[2];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            weights[0] = 1f;
            weights[1] = 0f;
            mixer.TransitionToSnapshots(snapshots, weights, 1f);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            weights[0] = 0f;
            weights[1] = 1f;
            mixer.TransitionToSnapshots(snapshots, weights, 1f);
        }
    }
}