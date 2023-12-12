using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalStick : MonoBehaviour
{
    [Header("attach")]
    public Transform center;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //set diraction
            Vector3 delta = center.position - other.transform.position;
            Vector3 fw = new Vector3(delta.x, 0, delta.z).normalized;
            other.transform.forward = fw;

            //start perform
            PlayerCtrl2.Instance.PlayerClearPerform();
        }
    }
}
