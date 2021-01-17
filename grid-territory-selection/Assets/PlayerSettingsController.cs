using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettingsController : MonoBehaviour
{
    TMP_InputField nameInput;
    TMP_InputField colorInput;
    Image colorDisplay;


    // Start is called before the first frame update
    void Start()
    {
        nameInput = transform.Find("NameInput").GetComponent<TMP_InputField>();
        colorInput = transform.Find("ColorInput").GetComponent<TMP_InputField>();
        colorDisplay = transform.Find("ColorDisplay").GetComponent<Image>();
        UpdateColor();
    }

    public void UpdateColor() {
        Color newColor;
        bool isUpdated = ColorUtility.TryParseHtmlString(colorInput.text, out newColor);
        colorDisplay.color = newColor;
    }

    public bool IsValidColor() {
        Color throwaway;
        return ColorUtility.TryParseHtmlString(colorInput.text, out throwaway);
    }

    public bool IsValid() {
        return nameInput.text.Length > 0 && IsValidColor();
    }

    public Color myColor() {
        return colorDisplay.color;
    }

    public string myName() {
        return nameInput.text;
    }
}
