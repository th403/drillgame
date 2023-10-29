using System;
using System.Collections;
using System.Collections.Generic;
using Digger.Modules.Core.Sources;
using Digger.Modules.Core.Sources.Operations;
using Unity.Jobs;
using UnityEngine;

//namespace Digger.Modules.Runtime.Sources
    public class DiggingPointCtrl : MonoBehaviour
{
        //public GameObject Camera;
        //public GameObject Player;
        public GameObject Effect;
        //public GameObject DirtAndSpace;
        public float length = 1.0f;
        public GameObject DiggerMasterRuntimeObj;
        private Digger.Modules.Runtime.Sources.DiggerMasterRuntime DMR;

        public float DiggingCooldown = 0.1f;
        private float time = 0;
        public bool AutoDig = true;

        private bool DoDigging = false;

        public BrushType brush;
        public ActionType action;
        private int textureIndex = 3;
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
            DMR = DiggerMasterRuntimeObj.GetComponent<Digger.Modules.Runtime.Sources.DiggerMasterRuntime>();
        }

        // Update is called once per frame
        void Update()
        {
            if(DoDigging)
            {
                time += Time.deltaTime;

                //深さよりテクスチャ変更
                textureIndex = 3;
                if (transform.position.y < 10)
                {
                    textureIndex = 5;
                }
                else if (transform.position.y < 100)
                {
                    textureIndex = 4;
                }

                //Vector3 direction = -(Camera.transform.position - Player.transform.position);
                //this.transform.position = Player.transform.position + direction.normalized * length;
                //if (Input.GetMouseButtonDown(0))
                //{
                //    GameObject clone = Instantiate(DirtAndSpace, transform.position, transform.rotation);
                //    if (Effect)
                //    {
                //        Instantiate(Effect, transform.position, transform.rotation);
                //    }

                //}

                ////コライダー自動////////////////////////////////////////
                if (AutoDig)
                {
                    if (transform.position.y < 10 && time >= DiggingCooldown)
                    {
                        time = 0;
                        //DoDigging = false;
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
                    ////全自動////////////////////////////////////////
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

                    ////半自動///////////////////////////////////////
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
    }

