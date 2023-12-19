using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// income expense effect
/// </summary>
public class InOutEffectController : MonoBehaviour
{
    private static InOutEffectController instance;

    private void Awake()
    {
        instance = this;
    }

    public static InOutEffectController Instance
    {
        get { return instance; }
    }

    [Header("attach")]
    public GameObject moneyEffectPrefab;

    //if ui canvas
    public RectTransform panel;
    public RectTransform canvas;
    public Transform showMoneyChangePos;

    [Header("test only")]
    //if world object ui
    [Range(0, 2)]
    public float size = 1.0f;

    public void Init(float size=1,Transform target=null)
    {
        //for run time modify
        this.size = size;
        //showMoneyChangePos = target;

        //set ui size
        //moneyEffectPrefab.GetComponent<InOutEffect>().digitPrefab.transform.localScale *= size;
        //moneyEffectPrefab.GetComponent<InOutEffect>().digitDistance *= size;


        //kari show on bar
        MainGameDataManager.Instance.money.OnValueChange += (oldVal, newVal) =>
        {
            float deltaVal = newVal - oldVal;
            MakeEffectOnBar((int)deltaVal);
        };
    }

    public void MakeEffect(Transform target,int num)
    {
        if (target == null) return;

        if (Camera.main == null) return;


        //instantiate gameobject and set position
        GameObject go = Instantiate(moneyEffectPrefab);
        //Vector3 pos = Camera.main.WorldToScreenPoint( Camera.main.WorldToViewportPoint(target.position));
        //Vector3 pos = Camera.main.WorldToScreenPoint(target.position);
        Vector3 pos = Camera.main.WorldToScreenPoint(target.position);

        //Vector3 pos = WorldToCameraSpace.WorldToScreenSpaceCamera(Camera.main, Camera.main, canvas,target.position);
        //Vector3 deltaPos= target.position - Camera.main.transform.position;
        //go.transform.localPosition = Vector3.zero;
        //go.GetComponent<RectTransform>().SetParent(panel);
        //go.transform.forward = deltaPos.normalized;

        //start effect
        InOutEffect2 effect = go.GetComponent<InOutEffect2>();
        effect.StartEffect(target,num);
    }


    public void MakeEffectOnBar(int num)
    {
        if (Camera.main == null) return;

        //instantiate gameobject and set position
        GameObject go = Instantiate(moneyEffectPrefab);
        InOutEffect2 effect = go.GetComponent<InOutEffect2>();
        effect.StartEffect(showMoneyChangePos, num);
    }
}
