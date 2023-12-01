using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableStartPoint : MonoBehaviour
{
    [Header("attach")]
    public Transform catTransform;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = new Ray(catTransform.position, Vector3.down);
        RaycastHit hit;
        Vector3 endPos;
        float groundDist = CableManager.Instance.groundDist;
        if (Physics.Raycast(ray, out hit, groundDist))
        {
            endPos = hit.point;
        }
        else
        {
            endPos = catTransform.position + Vector3.down * groundDist;
        }
        Debug.DrawLine(
            catTransform.position, 
            endPos,
            Color.yellow);
    }
}
