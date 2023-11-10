using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAss : MonoBehaviour
{
    public GameObject ass;
    public GameObject player;
    public float followSpd=0.4f;

    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //set same position
        transform.position = player.transform.position;

        //get ass world rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, followSpd);
    }
}
