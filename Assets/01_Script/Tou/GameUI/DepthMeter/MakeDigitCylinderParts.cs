using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MakeDigitCylinderParts : MonoBehaviour
{
    public GameObject numberPrefab;
    public Transform rig;
    public Transform initPos;

    public bool makeParts;
    public bool deleteParts;

    private void OnValidate()
    {
        if(makeParts)
        {
            makeParts = false;

            rig.localRotation = Quaternion.identity;
            for(int i=0;i<10;i++)
            {
                var go = Instantiate(numberPrefab, initPos);

                go.transform.SetParent(transform);
                go.GetComponent<TMP_Text>().text = i + "";

                rig.Rotate(360.0f / 10.0f, 0, 0);
            }
        }
    }
}
