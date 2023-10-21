using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Camera camera_Player;
    public Camera camera_Driller;
    public GameObject player;
    public GameObject driller;
    private DrillerRobo drillerRobo;

    // Start is called before the first frame update
    void Start()
    {
        camera_Player.enabled = true;
        camera_Driller.enabled = false;
        drillerRobo = camera_Driller.GetComponent<DrillerRobo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            camera_Player.enabled = !camera_Player.enabled;

            camera_Driller.enabled = !camera_Driller.enabled;
            drillerRobo.SetUse(camera_Driller.enabled);
        }
    }
}
