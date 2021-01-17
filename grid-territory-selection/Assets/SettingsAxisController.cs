using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsAxisController : MonoBehaviour
{
    Slider sizeSlider;
    TextMeshProUGUI sizeLabel;

    // Start is called before the first frame update
    void Awake()
    {
        sizeSlider = transform.Find("SizeSlider").GetComponent<Slider>();
        sizeLabel = transform.Find("SizeLabel").GetComponent<TextMeshProUGUI>();
    }

    private void Start() {
        UpdateLabel();
    }

    // Update is called once per frame
    public void UpdateLabel() {
        sizeLabel.text = sizeSlider.value + "";
    }

    public int getAxisCardCount() {
        return (int)sizeSlider.value;
    }
}
