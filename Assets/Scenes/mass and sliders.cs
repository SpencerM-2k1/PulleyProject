using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;



public class CubeWeightController : MonoBehaviour
{
    public Slider weightSlider;
    public GameObject targetCube;

    private Rigidbody targetCubeRb;

    void Start()
    {
        // Get the Rigidbody component of the target cube
        targetCubeRb = targetCube.GetComponent<Rigidbody>();

        // Add a listener to the slider
        weightSlider.onValueChanged.AddListener(UpdateWeight);
    }

    private void UpdateWeight(float value)
    {
        // Set the mass of the target cube based on the slider value
        if (targetCubeRb != null)
        {
            targetCubeRb.mass = value;
        }
    }
}


