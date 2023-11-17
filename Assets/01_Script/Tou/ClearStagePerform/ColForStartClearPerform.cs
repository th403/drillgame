using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColForStartClearPerform : MonoBehaviour
{
    [Header("attach")]
    public Transform center;
    public GameObject prefab;

    public Camera performCmr;
    public Camera mainCmr;
    public Transform cmrRig;

    [Header("edit")]
    public float groundPosY = 0.3f;
    public int animeFrame = 120;
    public float jumpHeight = 2.0f;
    public bool finish = false;

    private void OnTriggerEnter(Collider other)
    {
        if (finish) return;

        if(other.CompareTag("Player"))
        {
            Vector3 dir = (center.position - other.transform.position).normalized;
            Ray ray = new Ray(other.transform.position,dir);
            LayerMask layer = LayerMask.GetMask("ClearPoint");
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, 100,layer))
            {
                Vector3 groundPos = new Vector3(hit.point.x, groundPosY, hit.point.z);
                Instantiate(prefab, groundPos, Quaternion.identity);

                Debug.Log(groundPos);
                Vector3 delta = (groundPos - other.transform.position);
                float length = delta.magnitude;
                float height = jumpHeight;
                Vector3 jumpDir = new Vector3(delta.x, 0, delta.z).normalized;
                Vector3 velo = JumpTool.GetJumpVelocity(length, height, jumpDir);

                //exchange camera
                performCmr.enabled = true;
                mainCmr.enabled = false;
                cmrRig.forward = -jumpDir;

                //other.gameObject.GetComponent<Rigidbody>().velocity = velo;
                other.gameObject.GetComponent<PlayerCtrl2>().enabled = false;
                var move= other.gameObject.AddComponent<PlayerJumpMoveClip>();
                move.PlayClip(velo, 120.0f * 1.0f / 60,()=> {
                    //test
                    other.gameObject.GetComponent<PlayerCtrl2>().enabled = true;

                    //reset camera
                    performCmr.enabled = false;
                    mainCmr.enabled = true;
                    mainCmr.transform.position = performCmr.transform.position;
                    mainCmr.transform.rotation = performCmr.transform.rotation;

                    //start result 
                    ResultPanelController.Instance.StartShowResult();

                    //pause control?
                });

                //set anime
                CharaAnimeController.Instance.StartStick();

                finish = true;
                GetComponent<Collider>().enabled = false;
            }
        }
    }
}
