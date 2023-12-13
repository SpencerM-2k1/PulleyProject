using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportButtonScript : MonoBehaviour
{
    public Transform teleportLocation; // Assign the teleport target location in the Inspector

    private void Start()
    {
        Button teleportButton = GetComponent<Button>();
        teleportButton.onClick.AddListener(Teleport);
    }

    public void Teleport()
    {
        // Teleport the player to the specified location
        if (teleportLocation != null)
        {
            XRRig xrRig = FindObjectOfType<XRRig>();
            xrRig.transform.position = teleportLocation.position;
        }
    }
}
