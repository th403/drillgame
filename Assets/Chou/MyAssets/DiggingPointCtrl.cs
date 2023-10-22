using System;
using System.Collections;
using System.Collections.Generic;
using Digger.Modules.Core.Sources;
using Digger.Modules.Core.Sources.Operations;
using Unity.Jobs;
using UnityEngine;

namespace Digger.Modules.Runtime.Sources
{
    public class DiggingPointCtrl : ADiggerRuntimeMonoBehaviour
    {
        //public GameObject Camera;
        //public GameObject Player;
        public GameObject Effect;
        //public GameObject DirtAndSpace;
        public float length = 1.0f;
        public Vector3 SpaceScale = new Vector3(1.3f, 1.3f, 1.3f);
        public GameObject DiggerMasterRuntimeObj;
        private DiggerMasterRuntime DMR;

        public float DiggingCooldown = 1.0f;
        private float time = 0;
        public bool AutoDig = false;


        public BrushType brush;
        public ActionType action;
        public int textureIndex = 4;
        public float opacity = 1;
        public float size = 2;
        public float stalagmiteHeight = 8f;
        public bool stalagmiteUpsideDown = false;
        public bool opacityIsTarget = false;

        //public BrushType brush2;
        //public ActionType action2;
        //public int textureIndex2 = 4;
        //public float opacity2 = 1;
        //public float size2 = 2;
        //public float stalagmiteHeight2 = 8f;
        //public bool stalagmiteUpsideDown2 = false;
        //public bool opacityIsTarget2 = false;

        // Start is called before the first frame update
        void Start()
        {
            DMR = DiggerMasterRuntimeObj.GetComponent<DiggerMasterRuntime>();
        }

        // Update is called once per frame
        void Update()
        {
            time += Time.deltaTime;

            //Vector3 direction = -(Camera.transform.position - Player.transform.position);
            //this.transform.position = Player.transform.position + direction.normalized * length;
            //if (Input.GetMouseButtonDown(0))
            //{
            //    GameObject clone = Instantiate(DirtAndSpace, transform.position, transform.rotation);
            //    clone.transform.localScale = SpaceScale;
            //    if (Effect)
            //    {
            //        Instantiate(Effect, transform.position, transform.rotation);
            //    }

            //}

            ////AIŽ©“®////////////////////////////////////////
            if (AutoDig)
            {
                if (time >= DiggingCooldown)
                {
                    time = 0;
                    //(Vector3 position, BrushType brush, ActionType action, int textureIndex, float opacity,
                    //float size, float stalagmiteHeight = 8f, bool stalagmiteUpsideDown = false,
                    //bool opacityIsTarget = false)
                    DMR.Modify(transform.position, brush, action, textureIndex, opacity,
                    size, stalagmiteHeight, stalagmiteUpsideDown, opacityIsTarget);
                    //DMR.Modify(transform.position, brush2, action2, textureIndex2, opacity2,
                    //size2, stalagmiteHeight2, stalagmiteUpsideDown2, opacityIsTarget2);
                    if (Effect)
                    {
                        Instantiate(Effect, transform.position, transform.rotation);
                    }
                }

            }
            /////////////////////////////////////////////////

            else
            {
                ////‘SŽ©“®////////////////////////////////////////
                if (Input.GetMouseButton(0))
                {
                    if (time >= DiggingCooldown)
                    {
                        time = 0;
                        //(Vector3 position, BrushType brush, ActionType action, int textureIndex, float opacity,
                        //float size, float stalagmiteHeight = 8f, bool stalagmiteUpsideDown = false,
                        //bool opacityIsTarget = false)
                        DMR.Modify(transform.position, brush, action, textureIndex, opacity,
                        size, stalagmiteHeight, stalagmiteUpsideDown, opacityIsTarget);
                        //DMR.Modify(transform.position, brush2, action2, textureIndex2, opacity2,
                        //size2, stalagmiteHeight2, stalagmiteUpsideDown2, opacityIsTarget2);
                        if (Effect)
                        {
                            Instantiate(Effect, transform.position, transform.rotation);
                        }
                    }
                }
                /////////////////////////////////////////////////

                ////”¼Ž©“®///////////////////////////////////////
                if (Input.GetMouseButtonDown(1))
                {
                    //(Vector3 position, BrushType brush, ActionType action, int textureIndex, float opacity,
                    //float size, float stalagmiteHeight = 8f, bool stalagmiteUpsideDown = false,
                    //bool opacityIsTarget = false)
                    DMR.Modify(transform.position, brush, action, textureIndex, opacity,
                    size, stalagmiteHeight, stalagmiteUpsideDown, opacityIsTarget);

                    if (Effect)
                    {
                        Instantiate(Effect, transform.position, transform.rotation);
                    }

                }
                ///////////////////////////////////////////////

                ////Žè“®///////////////////////////////////////
                //if (Input.GetMouseButtonDown(1))
                //{
                //    if (time >= DiggingCooldown)
                //    {
                //        time = 0;
                //        //(Vector3 position, BrushType brush, ActionType action, int textureIndex, float opacity,
                //        //float size, float stalagmiteHeight = 8f, bool stalagmiteUpsideDown = false,
                //        //bool opacityIsTarget = false)
                //        DMR.Modify(transform.position, brush, action, textureIndex, opacity,
                //        size, stalagmiteHeight, stalagmiteUpsideDown, opacityIsTarget);

                //        if (Effect)
                //        {
                //            Instantiate(Effect, transform.position, transform.rotation);
                //        }

                //    }

                //}
                ///////////////////////////////////////////////
            }

        }

    }

}
