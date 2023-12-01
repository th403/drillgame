using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInEffectCtrl : MonoBehaviour
{
    public float Life = 0.5f;

    private float CountLife = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(CountLife>0)
        {
            CountLife -= Time.deltaTime;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public void StartFadeIn()
    {
        this.gameObject.SetActive(true);
        CountLife = Life;

    }
}
