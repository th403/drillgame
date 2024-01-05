using System;
using System.Collections;
using System.Collections.Generic;
using Digger.Modules.Core.Sources;
using Digger.Modules.Core.Sources.Operations;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.UI;

//namespace Digger.Modules.Runtime.Sources
public class DiggingPointCtrl : MonoBehaviour
{
    public TurtorialPanelManager turtorial;

    //public GameObject Camera;
    //public GameObject Player;
    public GameObject Effect;
    public GameObject DigArea;
    //public GameObject DirtAndSpace;
    public GameObject DiggerMasterRuntimeObj;
    public float DiggingCooldown = 0.1f;
    public bool AutoDig = true;
    public BrushType brush;
    public ActionType action;
    public int textureIndex = 3;
    public float opacity = 1;
    public float size = 2;
    public float stalagmiteHeight = 8f;
    public bool stalagmiteUpsideDown = false;
    public bool opacityIsTarget = false;
    public int FadeTime = 3;

    //public BrushType brush2;
    //public ActionType action2;
    //public int textureIndex2 = 4;
    //public float opacity2 = 1;
    //public float size2 = 2;
    //public float stalagmiteHeight2 = 8f;
    //public bool stalagmiteUpsideDown2 = false;
    //public bool opacityIsTarget2 = false;
    private bool DoDigging = false;
    private float ScaleRate = 1;
    private float time = 0;
    private Digger.Modules.Runtime.Sources.DiggerMasterRuntime DMR;
    private bool TurtorialClick = false;

    // Start is called before the first frame update
    void Start()
    {
        DMR = DiggerMasterRuntimeObj.GetComponent<Digger.Modules.Runtime.Sources.DiggerMasterRuntime>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        //深さよりテクスチャ変更
        textureIndex = 3;
        if (transform.position.y < -10)
        {
            textureIndex = 1;
            if (transform.position.y < -20)
            {
                textureIndex = 5;
                if (transform.position.y < -50)
                {
                    textureIndex = 4;
                }
            }
        }


        ////コライダー自動////////////////////////////////////////
        if (AutoDig)
        {
            if (DoDigging)
            {
                if (transform.position.y < 10 && time >= DiggingCooldown)
                {
                    time = 0;
                    //DoDigging = false;
                    //(Vector3 position, BrushType brush, ActionType action, int textureIndex, float opacity,
                    //float size * ScaleRate, float stalagmiteHeight = 8f, bool stalagmiteUpsideDown = false,
                    //bool opacityIsTarget = false)
                    DMR.Modify(transform.position, brush, action, textureIndex, opacity,
                    size * ScaleRate, stalagmiteHeight, stalagmiteUpsideDown, opacityIsTarget);
                    //DMR.Modify(transform.position, brush2, action2, textureIndex2, opacity2,
                    //size2 * ScaleRate, stalagmiteHeight2, stalagmiteUpsideDown2, opacityIsTarget2);
                    if (Effect)
                    {
                        Instantiate(Effect, transform.position, transform.rotation);
                    }
                }
            }
        }
        /////////////////////////////////////////////////

        else
        {
            ////全自動////////////////////////////////////////
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.JoystickButton1))
            {
                if (time >= DiggingCooldown)
                {
                    time = 0;
                    //(Vector3 position, BrushType brush, ActionType action, int textureIndex, float opacity,
                    //float size * ScaleRate, float stalagmiteHeight = 8f, bool stalagmiteUpsideDown = false,
                    //bool opacityIsTarget = false)
                    DMR.Modify(transform.position, brush, action, textureIndex, opacity,
                    size * ScaleRate, stalagmiteHeight, stalagmiteUpsideDown, opacityIsTarget);
                    //DMR.Modify(transform.position, brush2, action2, textureIndex2, opacity2,
                    //size2 * ScaleRate, stalagmiteHeight2, stalagmiteUpsideDown2, opacityIsTarget2);
                    if (Effect)
                    {
                        Instantiate(Effect, transform.position, transform.rotation);
                        TurtorialClick = true;
                    }
                    if (DigArea)
                    {
                        Instantiate(DigArea, transform.position, transform.rotation);
                    }
                    
                }
            }
            /////////////////////////////////////////////////

            ////半自動///////////////////////////////////////
            else if (Input.GetMouseButtonDown(1))
            {
                //(Vector3 position, BrushType brush, ActionType action, int textureIndex, float opacity,
                //float size * ScaleRate, float stalagmiteHeight = 8f, bool stalagmiteUpsideDown = false,
                //bool opacityIsTarget = false)
                DMR.Modify(transform.position, brush, action, textureIndex, opacity,
                size * ScaleRate, stalagmiteHeight, stalagmiteUpsideDown, opacityIsTarget);

                if (Effect)
                {
                    Instantiate(Effect, transform.position, transform.rotation);
                }
                if (DigArea)
                {
                    Instantiate(DigArea, transform.position, transform.rotation);
                }

            }
            ///////////////////////////////////////////////

            ////手動///////////////////////////////////////
            //if (Input.GetMouseButtonDown(1))
            //{
            //    if (time >= DiggingCooldown)
            //    {
            //        time = 0;
            //        //(Vector3 position, BrushType brush, ActionType action, int textureIndex, float opacity,
            //        //float size, float stalagmiteHeight = 8f, bool stalagmiteUpsideDown = false,
            //        //bool opacityIsTarget = false)
            //        DMR.Modify(transform.position, brush, action, textureIndex, opacity,
            //        size * ScaleRate, stalagmiteHeight, stalagmiteUpsideDown, opacityIsTarget);

            //        if (Effect)
            //        {
            //            Instantiate(Effect, transform.position, transform.rotation);
            //        }

            //    }

            //}
            ///////////////////////////////////////////////
        }

        if (TurtorialClick == true)
        {
            Invoke("OnTurtorialGoal", FadeTime);
            //Debug.Log("Damage");

        }


    }



    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Terrain")
    //    {
    //        DoDigging = true;
    //    }

    //}

    public void SetDiggingOn(bool use)
    {
        DoDigging = use;
    }
    public void SetScaleRate(float ParentScaleRate)
    {
        ScaleRate = ParentScaleRate;
    }
    public void StartDig(float strength, float size)
    {
        DMR.Modify(transform.position, brush, action, textureIndex, strength,
        size * ScaleRate, stalagmiteHeight, stalagmiteUpsideDown, opacityIsTarget);
    }

    public void OnTurtorialGoal()
    {
        turtorial.OnTurtorialGoal();
        //Debug.Log("Damage2");
       

    }

}

