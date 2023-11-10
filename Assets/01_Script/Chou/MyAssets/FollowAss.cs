using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAss : MonoBehaviour
{
    public GameObject ass;
    public float followSpd=0.02f;
    public float MinPlayerRotateSpeed = 1.0f;
    public GameObject Player;
    private Rigidbody PlayerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = Player.GetComponent<Rigidbody>();

        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //set same position
        transform.position = Player.transform.position;
        if (PlayerRigidbody.angularVelocity.y < MinPlayerRotateSpeed && PlayerRigidbody.angularVelocity.y > -MinPlayerRotateSpeed)
        {

            //get ass world rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, Player.transform.rotation, followSpd);

        }
    }
}
