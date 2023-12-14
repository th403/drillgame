using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DPadButtonSelector : MonoBehaviour
{
    public Button[] buttons; // �{�^����z��ŊǗ�
    public Slider[] sliders; // �X���C�_�[��z��ŊǗ�

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
            // D-pad�̏�����̓��͂�����ꍇ
            ChangeSelectedButton(-1); // ��Ɉړ�
            ChangeSelectedSlider(-1); // ��Ɉړ�
        }
        else if (verticalInput < -0.5f)
        {
            // D-pad�̉������̓��͂�����ꍇ
            ChangeSelectedButton(1); // ���Ɉړ�
            ChangeSelectedSlider(1); // ���Ɉړ�
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
