using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGroupController : MonoBehaviour
{
    public List<ButtonController> buttons;

    public void OnButtonSelected(ButtonController selectedButton)
    {

        foreach (var button in buttons)
        {
            if (button == selectedButton)
            {
                button.SetHighlightedState(true);
            }
            else
            {
                button.SetHighlightedState(false);
            }
        }
    }
}
