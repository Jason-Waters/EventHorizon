using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{
    
    private bool chase = false;
    private bool patrol = false;
    private bool stunned = false;
    private bool immune = false;
    private GameObject alien;



    public void UpdateState(int n)
    {
        switch (n)
        {
            case 1:
                alien.GetComponent<Patrol>().enabled = true;
                alien.GetComponent<Chase>().enabled = false;                
                break;
            case 2:
                alien.GetComponent<Chase>().enabled = true;
                alien.GetComponent<Patrol>().enabled = false;                
                break;
            case 3:
                //alien.GetComponent<Stunned>().enabled = true;
                break;
            case 4:
                //alien.GetComponent<Immune>().enabled = true;
                break;
            default:
                break;



        }

    }



    private void Awake()
    {
        alien = gameObject.GetComponent<GameManager>().alien;        

    }



}
