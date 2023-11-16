using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableManager : MonoBehaviour
{
    private static CableManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static CableManager Instance
    {
        get { return instance; }
    }

    [Header("attach")]
    public GameObject cablePrefab;
    public Transform catTransform;

    [Header("edit")]
    public float unitMaxLength;
    public float groundDist;

    [Header("read only")]
    public List<Transform> cables;
    public Cable currentCable;

    private void Start()
    {
        AddFirstCable();
    }

    void AddFirstCable()
    {
        AddCable(catTransform.position);
    }

    public void SetUpCable()
    {
        //make ray
        Ray ray = new Ray(catTransform.position, Vector3.down);
        LayerMask layer = LayerMask.GetMask("Terrain");
        RaycastHit hit;
        Vector3 endPos;
        if(Physics.Raycast( ray, out hit, groundDist, layer))
        {
            endPos = hit.point;
        }
        else
        {
            endPos = catTransform.position + Vector3.down * groundDist;
        }
        Vector3 dir = (endPos - currentCable.transform.position).normalized;
        currentCable.joint.forward = dir;

    }

    public void AddCable(Vector3 pos)
    {
        var go = Instantiate(cablePrefab);
        go.transform.position = pos;
        go.transform.SetParent(transform);
        cables.Add(go.transform);

        currentCable = go.GetComponent<Cable>();
        currentCable.cat = catTransform;
    }

    public int GetCableCount()
    {
        return cables.Count;
    }
}
