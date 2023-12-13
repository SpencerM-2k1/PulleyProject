using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public Text valueText; // Optional, for displaying the current value

    private void Start()
    {
        // Subscribe to the slider's value changed event
        slider.onValueChanged.AddListener(OnSliderValueChanged);

        // Optionally, update the UI Text with the initial value
        UpdateValueText(slider.value);
    }

    private void OnSliderValueChanged(float value)
    {
        // Handle the slider value change here
        Debug.Log("Slider value changed to: " + value);

        // Optionally, update the UI Text with the current value
        UpdateValueText(value);
    }

    private void UpdateValueText(float value)
    {
        // Optional: Update the UI Text with the current value
        if (valueText != null)
        {
            valueText.text = "Value: " + value.ToString("F2"); // Format the value as needed
        }
    }
}

