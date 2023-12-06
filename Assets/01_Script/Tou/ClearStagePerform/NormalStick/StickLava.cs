using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("attach")]
    public Transform center;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            var ctrl = other.GetComponent<PlayerCtrl2>();
            //ctrl.Sp

            Vector3 delta = center.position - other.transform.position;
            Vector3 fw = new Vector3(delta.x, 0, delta.z).normalized;
            other.transform.forward = fw;
            CharaAnimeController.Instance.StartStick();
        }
    }
}
