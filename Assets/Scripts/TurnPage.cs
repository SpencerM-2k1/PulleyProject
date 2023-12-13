using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurnPage : MonoBehaviour
{
    // Start is called before the first frame update
    
    public const int PAGE1 = 2;
    public const int PAGE2 = 3;
    public const int PAGE3 = 4;
    public const int PAGE4 = 5;

    public int activePage;
    public int currentPage;

    public void Start()
    {
        currentPage = 1;
        activePage = currentPage;
    }

    public void ShowNextPage()
    {
        if(currentPage < 4)
        {
            currentPage++;
            SwitchPage();
        }
    }
    public void ShowPrevPage()
    {
        if(currentPage > 1)
        {
            currentPage--;
            SwitchPage();
        }
    }

    public void SwitchPage()
    {
        //Disable old page
        switch(activePage)
        {
            case 1:
                transform.GetChild(PAGE1).gameObject.SetActive(false);
                break;
            case 2:
                transform.GetChild(PAGE2).gameObject.SetActive(false);
                break;
            case 3:
                transform.GetChild(PAGE3).gameObject.SetActive(false);
                break;
            case 4:
                transform.GetChild(PAGE4).gameObject.SetActive(false);
                break;
            default:
                break;
        }

        //Enable new page
        switch(currentPage)
        {
            case 1:
                transform.GetChild(PAGE1).gameObject.SetActive(true);
                break;
            case 2:
                transform.GetChild(PAGE2).gameObject.SetActive(true);
                break;
            case 3:
                transform.GetChild(PAGE3).gameObject.SetActive(true);
                break;
            case 4:
                transform.GetChild(PAGE4).gameObject.SetActive(true);
                break;
            default:
                break;
        }

        //Update active page
        activePage = currentPage;
    }
}
