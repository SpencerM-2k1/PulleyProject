using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchButton : MonoBehaviour
{
    public string MainMenuScene; // The name of your main scene.

    private void OnMouseDown()
    {
        // Load the specified scene when the button is clicked.
        SceneManager.LoadScene("AboutScene");
    }
}

