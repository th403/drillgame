using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingAtPointCtrl : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerCamera;
    public float Height = 1.0f;
    public float DistanceChangeRate = 0.5f;
    public float DistanceChangeSpeed = 1.0f;

    private Rigidbody PlayerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = Player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float TargetZ = PlayerRigidbody.velocity.magnitude* DistanceChangeRate;
        float NowZ = transform.localPosition.z;
        transform.localPosition += new Vector3(0, 0, (TargetZ - NowZ) * DistanceChangeSpeed * Time.deltaTime);

        Vector3 DistanceToCamera = PlayerCamera.transform.position - transform.position;
        DistanceToCamera.y = 0;
        if (DistanceToCamera.magnitude < transform.localPosition.z)
        {
            Vector2 PlayerDistanceToCamera2D = Player.transform.position - PlayerCamera.transform.position;
            PlayerDistanceToCamera2D.y = 0;
            transform.localPosition = new Vector3(0, Height, PlayerDistanceToCamera2D.magnitude * 0.5f);
        }

    }

    void FixedUpdate()
    {

    }


}
