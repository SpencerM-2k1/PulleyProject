using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PulleyAccelerationCalculator : MonoBehaviour
{
    //public InputField mass1Input;
    public Slider mass1Input; //m_Value
    //public InputField mass2Input;
    public Slider mass2Input; //m_Value
    public Text stepsText;
    public Text resultText;

    public void CalculateAcceleration()
    {
        // Parse user input for mass m1 and m2
        float m1 = mass1Input.value, m2 = mass2Input.value;
        //if (float.TryParse(mass1Input.text, out m1) && float.TryParse(mass2Input.text, out m2))
        if ((m1 + m2) != 0)
        {
            // Calculate acceleration
            float g = 9.81f;  // Acceleration due to gravity (m/s^2)
            float acceleration = ((m1 - m2) / (m1 + m2)) * g;

            // Display the steps and result
            stepsText.text = "Steps:\n" +
                "a = ((m1 - m2) / (m1 + m2)) * g\n" +
                "a = ((" + m1 + " - " + m2 + ") / (" + m1 + " + " + m2 + ")) * " + g + "\n" +
                "a = " + acceleration.ToString("F2") + " m/s^2";

            resultText.text = "Acceleration (a): " + acceleration.ToString("F2") + " m/s^2";
        }
        else
        {
            // Display an error message if input is invalid
            resultText.text = "Invalid input. Please enter valid masses for m1 and m2.";
        }
    }
}

