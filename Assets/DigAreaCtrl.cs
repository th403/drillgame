using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigAreaCtrl : MonoBehaviour
{
    public float Life = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Life -= Time.deltaTime;
        if(Life<=0)
        {
            Destroy(this.gameObject);
        }
    }
}
