using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaObjForTrap : MonoBehaviour
{
    public GameObject Effect;
    public int Damage=3000;

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
            if (Effect)
            {
                GameObject clone = Instantiate(Effect, transform.position, transform.rotation);
                clone.transform.localScale = transform.localScale;
            }
            EventCtrl.Instance.PlayerGetMoney(-Damage);

            Destroy(this.gameObject);
        }

    }

}
