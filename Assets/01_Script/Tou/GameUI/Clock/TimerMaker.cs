using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerMaker : MonoBehaviour
{
    [Header("attach")]
    public GameObject piecePrefab;
    public Transform center;
    public ClockController ctrl;

    [Header("edit")]
    public int pieceMax = 60;
    public float warnRate = 0.9f;

    [Header("button")]
    public bool make;

    private void OnValidate()
    {
        if (make)
        {
            make = false;
            ctrl.pieceMax = pieceMax;
            ctrl.warnRate = warnRate;
            for (int i = 0; i < pieceMax; i++)
            {
                var go = Instantiate(piecePrefab);
                go.transform.SetParent(center);
                go.transform.localEulerAngles = new Vector3(0, 0, 360.0f / pieceMax * i);
                go.transform.localPosition = Vector3.zero;

                var piece = go.GetComponent<TimerPiece>();
                if ((float)(i) / pieceMax > warnRate)
                {
                    piece.SetColor(ctrl.warnColor);
                }
                else
                {
                    piece.SetColor(ctrl.safeColor);
                }
                ctrl.pieces.Add(piece);
            }
        }
    }
}
