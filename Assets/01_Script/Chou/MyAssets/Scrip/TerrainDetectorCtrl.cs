using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainDetectorCtrl : MonoBehaviour
{
    public GameObject DiggingEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Terrain")
        {
            DiggingEffect.SetActive(true);
        }
        else
        {
            DiggingEffect.SetActive(false);

        }
    }

}
