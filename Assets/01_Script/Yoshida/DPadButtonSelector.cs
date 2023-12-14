using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DPadButtonSelector : MonoBehaviour
{
    public Button[] buttons; // ボタンを配列で管理
    public Slider[] sliders; // スライダーを配列で管理

    private int selectedButtonIndex = 0;
    private int selectedSliderIndex = 0;

    void Start()
    {
        SetButtonSelection(selectedButtonIndex);
        SetSliderSelection(selectedSliderIndex);
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput > 0.5f)
        {
            // D-padの上方向の入力がある場合
            ChangeSelectedButton(-1); // 上に移動
            ChangeSelectedSlider(-1); // 上に移動
        }
        else if (verticalInput < -0.5f)
        {
            // D-padの下方向の入力がある場合
            ChangeSelectedButton(1); // 下に移動
            ChangeSelectedSlider(1); // 下に移動
        }
    }

    void ChangeSelectedButton(int direction)
    {
        selectedButtonIndex = (selectedButtonIndex + direction + buttons.Length) % buttons.Length;
        SetButtonSelection(selectedButtonIndex);
    }

    void ChangeSelectedSlider(int direction)
    {
        selectedSliderIndex = (selectedSliderIndex + direction + sliders.Length) % sliders.Length;
        SetSliderSelection(selectedSliderIndex);
    }

    void SetButtonSelection(int index)
    {
        EventSystem.current.SetSelectedGameObject(buttons[index].gameObject);
    }

    void SetSliderSelection(int index)
    {
        EventSystem.current.SetSelectedGameObject(sliders[index].gameObject);
    }
}
