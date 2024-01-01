using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaObjForTrap : MonoBehaviour
{
    public GameObject Effect;
    public int Damage=3000;
    public GameObject MinusEffect;

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
        if(other.tag=="Terrain")
        {
            if(Effect)
            {
                Instantiate(Effect, transform.position, transform.rotation);
            }
            Destroy(this.gameObject);
        }
        if (other.tag == "Player")
        {
            if (Effect && MinusEffect)
            {
                GameObject effectClone = Instantiate(Effect, transform.position, transform.rotation);
                effectClone.transform.localScale = transform.localScale;

                GameObject minusEffectClone = Instantiate(MinusEffect, transform.position, transform.rotation);
                //minusEffectClone.transform.localScale = transform.localScale;
            }

            EventCtrl.Instance.PlayerGetMoney(-Damage);
            Destroy(this.gameObject);
        }

    }

}
