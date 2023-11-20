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
    public RectTransform panel;
    public RectTransform canvas;

    public void MakeEffect(Transform target,int num)
    {
        //instantiate gameobject and set position
        GameObject go = Instantiate(moneyEffectPrefab);
        //Vector3 pos = Camera.main.WorldToScreenPoint( Camera.main.WorldToViewportPoint(target.position));
        //Vector3 pos = Camera.main.WorldToScreenPoint(target.position);

        //Vector3 pos = WorldToCameraSpace.WorldToScreenSpaceCamera(Camera.main, Camera.main, canvas,target.position);
        Vector3 deltaPos= target.position - Camera.main.transform.position;
        Vector3 pos = target.position + deltaPos.normalized * -1f;
        go.transform.position = pos;
        //go.GetComponent<RectTransform>().SetParent(panel);
        go.transform.forward = deltaPos.normalized;

        //start effect
        InOutEffect effect = go.GetComponent<InOutEffect>();
        effect.StartEffect(num);
    }
}
