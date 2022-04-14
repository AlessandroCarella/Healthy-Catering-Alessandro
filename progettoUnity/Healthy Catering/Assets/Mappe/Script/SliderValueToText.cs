using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System;

public class SliderValueToText : MonoBehaviour
{
    public Slider sliderUI;
    private TextMeshProUGUI textSliderValue;
    

    void Start()
    {
        textSliderValue = GetComponent<TextMeshProUGUI>();
    }

    public void aggiornaValore()
    {
        textSliderValue.text = sliderUI.value.ToString();
    }

    public void aggiornaValorePercentuale()
    {
        float valoreCaricamento = sliderUI.value * 100f;
        Debug.Log(valoreCaricamento.ToString());
        textSliderValue.text = valoreCaricamento + "%";
    }


}