using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Rigidbody targetRigidbody; // Drag the object's Rigidbody you want to increase in mass to this field in the Inspector
    public float massIncreaseAmount = 1.0f;

    void Start()
    {
        if (targetRigidbody == null)
        {
            Debug.LogError("Target Rigidbody not assigned. Please drag the GameObject's Rigidbody to the Inspector.");
        }
    }

    public void OnButtonClicked()
    {
        IncreaseMassByAmount();
    }

    void IncreaseMassByAmount()
    {
        targetRigidbody.mass += massIncreaseAmount;
        Debug.Log("Mass increased to: " + targetRigidbody.mass);
    }
}

