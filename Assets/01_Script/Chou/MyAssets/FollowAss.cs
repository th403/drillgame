using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAss : MonoBehaviour
{
    public GameObject ass;
    public float followSpd=2f;
    public float RotateSpd = 1f;
    public float MinPlayerRotateSpeed = 1.0f;
    public GameObject Player;
    private Rigidbody PlayerRigidbody;
    private PlayerCtrl playerCtrl;
    public float ResetDelayMax=2;
    private float ResetDelay;
    // Start is called before the first frame update
    void Start()
    {
        ResetDelay = ResetDelayMax;
        PlayerRigidbody = Player.GetComponent<Rigidbody>();
        playerCtrl= Player.GetComponent<PlayerCtrl>(); 
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //set same position
        transform.position = Player.transform.position;
        ResetDelay -= Time.deltaTime;

        if(Input.GetAxis("4thHorizontal") !=0)
        {
            ResetDelay = ResetDelayMax;
            //AimRotationY = transform.rotation.y;
        }
        if(playerCtrl.GetIfMoving())
        {
            ResetDelay = 0;
        }
        if (ResetDelay > 0)
        {
            float rotationY = Input.GetAxis("4thHorizontal") * RotateSpd * Time.deltaTime; ;

            transform.Rotate(0, rotationY , 0, Space.Self);

        }
        else
        {

            if (PlayerRigidbody.angularVelocity.y < MinPlayerRotateSpeed && PlayerRigidbody.angularVelocity.y > -MinPlayerRotateSpeed)
            {
                //get ass world rotation
                transform.rotation = Quaternion.Lerp(transform.rotation, Player.transform.rotation, followSpd*Time.deltaTime);
            }
        }




    }
}
