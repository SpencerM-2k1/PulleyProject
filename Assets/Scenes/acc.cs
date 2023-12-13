using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;

public class PulleySystem : MonoBehaviour
{
    public Slider massSlider1;
    public Slider massSlider2;
    public Text resultText;
    public Text stepsText;

    private void Update()
    {
        // Get masses from sliders
        float m1 = massSlider1.value;
        float m2 = massSlider2.value;

        // Calculate acceleration
        float g = 9.8f; // acceleration due to gravity
        float acceleration = (m1 - m2) * g / (m1 + m2);

        // Display the result
        resultText.text = $"Acceleration: {acceleration:F2} m/s²";

        // Display the steps
        stepsText.text = $"Step 1: Calculate net force = (m1 - m2) * g\n" +
                         $"Step 2: Calculate total mass = m1 + m2\n" +
                         $"Step 3: Calculate acceleration = net force / total mass\n" +
                         $"      = ({m1} - {m2}) * {g} / ({m1} + {m2})\n" +
                         $"      = {acceleration:F2} m/s²";

        // You can also show more detailed steps or any other information as needed
        // For example:
        // stepsText.text = $"Step 1: Calculate net force = (m1 - m2) * g\n" + 
        //                  $"Step 2: ...";
    }
}

