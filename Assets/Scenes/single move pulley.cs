using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine;
using UnityEngine.UI;

public class SingleMovablePulley : MonoBehaviour
{
    public Slider massSlider;
    public Slider forceSlider;
    public Text infoText;  // UI Text element to display information

    private float mass;          // Initial mass
    private float forceApplied;  // Initial force
    private float acceleration;  // Calculated acceleration

    void Start()
    {
        // Set initial values of the sliders based on initial mass and force
        mass = massSlider.value;
        forceApplied = forceSlider.value;

        // Set initial text on the canvas
        UpdateInfoText();

        // Add listeners to the sliders to update values when they change
        massSlider.onValueChanged.AddListener(UpdateMass);
        forceSlider.onValueChanged.AddListener(UpdateForce);
    }

    void Update()
    {
        // Recalculate acceleration continuously as the slider values change
        CalculateAcceleration();

        // Update text on the canvas
        UpdateInfoText();
    }

    void CalculateAcceleration()
    {
        // Calculate acceleration using Newton's second law: a = F/m
        acceleration = forceApplied / mass;
    }

    void UpdateMass(float value)
    {
        // Update mass from the slider value
        mass = value;
    }

    void UpdateForce(float value)
    {
        // Update force from the slider value
        forceApplied = value;
    }

    void UpdateInfoText()
    {
       infoText.text = $"Calculation Steps:\n";
        infoText.text += $"1. Force Applied (F) = {forceApplied} N\n";
        infoText.text += $"2. Mass (m) = {mass} kg\n";
        infoText.text += $"3. Acceleration (a) = F / m\n";
        infoText.text += $"   = {forceApplied} / {mass}\n";
        infoText.text += $"   = {acceleration} m/s^2";
    }
}







