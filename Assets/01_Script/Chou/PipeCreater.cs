using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCreater : MonoBehaviour
{
    public GameObject Pipe;
    private Vector3 LastPipeEndPos;
    private bool Use=true;


    // Start is called before the first frame update
    void Start()
    {
        LastPipeEndPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(Use)
        {
            Ray ray = new Ray(transform.position, transform.position + new Vector3(0, -1.0f, 0));
            RaycastHit hitPoint;
            if(Physics.Raycast(ray, out hitPoint, 2.50f))
            {
                float distanceP = Vector3.Distance(hitPoint.point, LastPipeEndPos);

                if (distanceP >= 5)
                {
                    GameObject newPipe;
                    //CountPipe++;
                    newPipe = Instantiate(Pipe, (transform.position + LastPipeEndPos) / 2, transform.rotation);
                    newPipe.gameObject.transform.LookAt(LastPipeEndPos);
                    LastPipeEndPos = hitPoint.point;

                }
            }


        }

    }
}
