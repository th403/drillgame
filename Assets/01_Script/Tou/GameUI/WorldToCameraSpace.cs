using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldToCameraSpace
{
    /// <summary>
    /// ���[���h���W�� Screen Space - Camera �� Canvas ���̃��[�J�����W�ɕϊ����܂�
    /// </summary>
    /// <param name="worldCamera">���[���h���W��`�悷��J����</param>
    /// <param name="canvasCamera">Canvas ��`�悷��J����</param>
    /// <param name="canvasRectTransform">Canvas �� RectTransform</param>
    /// <param name="worldPosition">�ϊ��O�̃��[���h���W</param>
    /// <returns>�ϊ���̃��[�J�����W</returns>
    public static Vector3 WorldToScreenSpaceCamera
    (
        Camera worldCamera,
        Camera canvasCamera,
        RectTransform canvasRectTransform,
        Vector3 worldPosition
    )
    {
        var screenPoint = RectTransformUtility.WorldToScreenPoint
        (
            cam: worldCamera,
            worldPoint: worldPosition
        );

        RectTransformUtility.ScreenPointToLocalPointInRectangle
        (
            rect: canvasRectTransform,
            screenPoint: screenPoint,
            cam: canvasCamera,
            localPoint: out var localPoint
        );

        return localPoint;
    }
}
