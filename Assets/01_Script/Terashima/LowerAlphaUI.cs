using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LowerAlphaUI : MonoBehaviour
{
    public float alphaDecreaseRate = 0.1f; // �A���t�@�l�����������郌�[�g
    public float delayBeforeStart = 2.0f; // �x���J�n�̕b��

    void OnEnable()
    {
        // delayBeforeStart�b���LowerAlphaRecursively�����s
        Invoke("StartLoweringAlpha", delayBeforeStart);
    }

    void StartLoweringAlpha()
    {
        // �A���t�@�l�����������鏈�������s
        StartCoroutine(LowerAlphaRecursively(transform));
    }

    IEnumerator LowerAlphaRecursively(Transform currentTransform)
    {
        // �I�u�W�F�N�g��Image�R���|�[�l���g���擾
        Image image = currentTransform.GetComponent<Image>();

        // TextMeshProUGUI�R���|�[�l���g���擾
        TextMeshProUGUI textMeshPro = currentTransform.GetComponent<TextMeshProUGUI>();

        while (image != null && image.color.a > 0f)
        {
            // �A���t�@�l�����������鏈��
            LowerAlpha(image);

            // �A���t�@�l�����������鏈��
            LowerAlpha(textMeshPro);

            yield return null; // 1�t���[���ҋ@
        }

        // �q�I�u�W�F�N�g������ꍇ�A�ċA�I�ɌĂяo��
        foreach (Transform child in currentTransform)
        {
            yield return StartCoroutine(LowerAlphaRecursively(child));
        }
    }

    void LowerAlpha(Image image)
    {
        // Image�R���|�[�l���g�����݂��Acolor�v���p�e�B���g�p�\�ȏꍇ�ɃA���t�@�l������������
        if (image != null && image.color.a > 0f)
        {
            Color color = image.color;
            color.a -= alphaDecreaseRate * Time.deltaTime;

            // �A���t�@�l��0��菬�����ꍇ��0�ɃN�����v
            color.a = Mathf.Max(color.a, 0f);

            image.color = color;

            // �}�e���A��������΃}�e���A���̃A���t�@�l���ύX
            Material material = image.material;
            if (material != null)
            {
                Color materialColor = material.color;
                materialColor.a = color.a;
                material.color = materialColor;
            }
        }
    }

    void LowerAlpha(TextMeshProUGUI textMeshPro)
    {
        // TextMeshProUGUI�R���|�[�l���g�����݂��Acolor�v���p�e�B���g�p�\�ȏꍇ�ɃA���t�@�l������������
        if (textMeshPro != null && textMeshPro.color.a > 0f)
        {
            Color color = textMeshPro.color;
            color.a -= alphaDecreaseRate * Time.deltaTime;

            // �A���t�@�l��0��菬�����ꍇ��0�ɃN�����v
            color.a = Mathf.Max(color.a, 0f);

            textMeshPro.color = color;

            // �}�e���A��������΃}�e���A���̃A���t�@�l���ύX
            Material material = textMeshPro.material;
            if (material != null)
            {
                Color materialColor = material.color;
                materialColor.a = color.a;
                material.color = materialColor;
            }
        }
    }
}