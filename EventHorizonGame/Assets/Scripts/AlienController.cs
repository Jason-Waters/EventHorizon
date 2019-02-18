using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{


    
    
    private int defaultState = 1;
    


    public void UpdateState(int n)
    {
        
        switch (n)
        {
            case 1:
                gameObject.GetComponent<Patrol>().enabled = true;
                gameObject.GetComponent<Chase>().enabled = false;                
                break;
            case 2:                
                gameObject.GetComponent<Chase>().enabled = true;
                gameObject.GetComponent<Patrol>().enabled = false;                
                break;
            case 3:
                Debug.Log("Updating to Immune state");
                gameObject.GetComponent<Immune>().enabled = true;
                break;
            default:
                break;



        }

    }



    private void Start()
    {
        
        UpdateState(defaultState);
    }












}
