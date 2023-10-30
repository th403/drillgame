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

    public GameObject cablePrefab;
    public float unitMaxLength;
    public Transform catTransform;

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
