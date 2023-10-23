using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralCtrl : MonoBehaviour
{
    //public float PhysicalEffect = 100;
    //public float FlameEffect = 50;
    //public float ChemicalEffect = 0;
    public float HP = 10;
    public GameObject Dropping;
    private float CountDamage = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CountDamage >= 10)
        {
            HP -= CountDamage;

            if (Dropping)
            {
                Instantiate(Dropping, transform.position, transform.rotation);
            }

            if (HP <= 0)
            {
                Destroy(this.gameObject);
            }
            CountDamage -= 10;
        }

    }

    public void TakeDamage(float damage)
    {
        CountDamage += damage;
    }
}
