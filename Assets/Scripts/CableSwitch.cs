using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableSwitch : MonoBehaviour
{

    //Add switchable weights as a child of this object

    public Filo.Cable targetCable;
    public int targetLink;
    int currentWeight = -1;
    int weightCount = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        weightCount = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("space key was pressed");
            switchWeights();
        }
    }

    void switchWeights()
    {
        currentWeight++;
        currentWeight = currentWeight % weightCount;
        targetCable.changeAttachment(transform.GetChild(currentWeight).GetComponent<Filo.CableBody>(), targetLink);
    }

}
