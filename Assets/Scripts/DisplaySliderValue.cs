using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplaySliderValue : MonoBehaviour
{
    public Slider slider;
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.GetComponent<TMP_Text>().text = slider.value.ToString();
    }
}
