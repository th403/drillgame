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

    public GameObject moneyEffectPrefab;
    public RectTransform panel;

    public void MakeEffect(Transform target,int num)
    {
        //instantiate gameobject and set position
        GameObject go = Instantiate(moneyEffectPrefab);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);
        go.GetComponent<RectTransform>().localPosition = screenPos;
        go.GetComponent<RectTransform>().SetParent(panel);

        //start effect
        InOutEffect effect = go.GetComponent<InOutEffect>();
        effect.StartEffect(num);
    }
}
