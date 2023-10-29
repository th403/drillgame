using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public Transform t_obj;
    public Transform targetObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate(t_obj, targetObj, 0.01f);

    }

    public void Rotate(Transform transform, Transform target, float fRotateSpeed)
    {
        Vector3 targetDir = target.position - transform.position;
        if (targetDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDir, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, fRotateSpeed);
        }
    }
}
