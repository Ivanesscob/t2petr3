using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public string buttonResult = "";

    private Button button;
    private Image buttonImage;

    public Color normalColor = Color.white;
    public Color highlightedColor = new Color(0.3f, 0.3f, 0.3f);


    private ButtonGroupController buttonGroup;

    void Start()
    {
      
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();

        
        button.onClick.AddListener(OnButtonClick);

        
        buttonImage.color = normalColor;

       
        buttonGroup = FindObjectOfType<ButtonGroupController>();
        if (buttonGroup != null && !buttonGroup.buttons.Contains(this))
        {
            buttonGroup.buttons.Add(this);
        }
    }


    public void OnButtonClick()
    {

        if (buttonGroup != null)
        {
            buttonGroup.OnButtonSelected(this);
        }

        buttonResult = gameObject.name;
        Debug.Log("Выбран персонаж: " + buttonResult);

        // Сообщаем SceneSwitcher о том, что персонаж выбран
        SceneSwitcher sceneSwitcher = FindObjectOfType<SceneSwitcher>();
        if (sceneSwitcher != null)
        {
            sceneSwitcher.isCharacterSelected = true;
        }
    }

    public void SetHighlightedState(bool isHighlighted)
    {
       
        buttonImage.color = isHighlighted ? highlightedColor : normalColor;
    }
}
