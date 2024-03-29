

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainmenuScript : MonoBehaviour
{
    UIDocument _uIDocument;
    Button _Button;

    [SerializeField] List<Button> menuButtons = new List<Button>();
    void OnEnable()
    {
        _uIDocument = transform.GetComponent<UIDocument>();
        _Button = _uIDocument.rootVisualElement.Q("Mainmenu1") as Button;
        _Button.RegisterCallback<ClickEvent>(ClickButton);
        menuButtons = _uIDocument.rootVisualElement.Query<Button>().ToList();


        for (int i = 0; i < menuButtons.Count; i++)
        {
            menuButtons[i].RegisterCallback<ClickEvent>(AllButtonClick);
        }
    }

    void OnDisable()
    {
        _Button.UnregisterCallback<ClickEvent>(ClickButton);

        for (int i = 0; i < menuButtons.Count; i++)
        {
            menuButtons[i].UnregisterCallback<ClickEvent>(AllButtonClick);
        }
    }

    void ClickButton(ClickEvent _clickAction)
    {
        Debug.Log("ClickButton");
    }

    void AllButtonClick(ClickEvent _Clickevent)
    {
        Debug.LogError("All buttons Clcicked");
    }
}
