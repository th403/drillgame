using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LowerAlphaUI : MonoBehaviour
{
    public float alphaDecreaseRate = 0.1f; // アルファ値を減少させるレート
    public float delayBeforeStart = 2.0f; // 遅延開始の秒数

    void OnEnable()
    {
        // delayBeforeStart秒後にLowerAlphaRecursivelyを実行
        Invoke("StartLoweringAlpha", delayBeforeStart);
    }

    void StartLoweringAlpha()
    {
        // アルファ値を減少させる処理を実行
        StartCoroutine(LowerAlphaRecursively(transform));
    }

    IEnumerator LowerAlphaRecursively(Transform currentTransform)
    {
        // オブジェクトのImageコンポーネントを取得
        Image image = currentTransform.GetComponent<Image>();

        // TextMeshProUGUIコンポーネントを取得
        TextMeshProUGUI textMeshPro = currentTransform.GetComponent<TextMeshProUGUI>();

        while (image != null && image.color.a > 0f)
        {
            // アルファ値を減少させる処理
            LowerAlpha(image);

            // アルファ値を減少させる処理
            LowerAlpha(textMeshPro);

            yield return null; // 1フレーム待機
        }

        // 子オブジェクトがある場合、再帰的に呼び出す
        foreach (Transform child in currentTransform)
        {
            yield return StartCoroutine(LowerAlphaRecursively(child));
        }
    }

    void LowerAlpha(Image image)
    {
        // Imageコンポーネントが存在し、colorプロパティが使用可能な場合にアルファ値を減少させる
        if (image != null && image.color.a > 0f)
        {
            Color color = image.color;
            color.a -= alphaDecreaseRate * Time.deltaTime;

            // アルファ値が0より小さい場合は0にクランプ
            color.a = Mathf.Max(color.a, 0f);

            image.color = color;

            // マテリアルがあればマテリアルのアルファ値も変更
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
        // TextMeshProUGUIコンポーネントが存在し、colorプロパティが使用可能な場合にアルファ値を減少させる
        if (textMeshPro != null && textMeshPro.color.a > 0f)
        {
            Color color = textMeshPro.color;
            color.a -= alphaDecreaseRate * Time.deltaTime;

            // アルファ値が0より小さい場合は0にクランプ
            color.a = Mathf.Max(color.a, 0f);

            textMeshPro.color = color;

            // マテリアルがあればマテリアルのアルファ値も変更
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