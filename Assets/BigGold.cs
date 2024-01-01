using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGold : MonoBehaviour
{
    public GameObject Gold;
    public bool Test=false;
    public Vector3 RandomPosRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Test)
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 randV = new Vector3(Random.Range(-RandomPosRange.x, RandomPosRange.x), 
                    Random.Range(-RandomPosRange.y, RandomPosRange.y), 
                    Random.Range(-RandomPosRange.z, RandomPosRange.z));
                GameObject gold = Instantiate(Gold, transform.position+ randV, transform.rotation);
                gold.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                gold.GetComponent<Rigidbody>().useGravity = true;
                gold.GetComponent<Rigidbody>().constraints = 0;
                gold.GetComponent<Rigidbody>().AddForce(randV, ForceMode.VelocityChange);

            }
            Destroy(this.gameObject);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Driller")
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 randV = new Vector3(Random.Range(-RandomPosRange.x, RandomPosRange.x),
                    Random.Range(-RandomPosRange.y, RandomPosRange.y),
                    Random.Range(-RandomPosRange.z, RandomPosRange.z));
                GameObject gold = Instantiate(Gold, transform.position + randV, transform.rotation);
                gold.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                gold.GetComponent<Rigidbody>().useGravity = true;
                gold.GetComponent<Rigidbody>().constraints = 0;
                gold.GetComponent<Rigidbody>().AddForce(randV, ForceMode.VelocityChange);

            }
            Destroy(this.gameObject);

        }

    }


}
