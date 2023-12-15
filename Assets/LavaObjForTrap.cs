using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaObjForTrap : MonoBehaviour
{
    public GameObject Effect;
    public int Damage=3000;
    public AudioSource SELavaDestroy;

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
            //SoundManger.Instance.PlaySELavaDrop();
            SELavaDestroy.Play();
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
            //SoundManger.Instance.PlaySELavaDrop();
            SELavaDestroy.Play();
            Destroy(this.gameObject);
        }

    }

}
