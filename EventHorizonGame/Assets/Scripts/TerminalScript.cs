using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalScript : MonoBehaviour
{
    private bool inTrigger = false;
    private GameObject[] terminalDoor;
    public bool gotKey = false;
    private GameObject[] escapeDoor;
    // Start is called before the first frame update
    void Start()
    {
        terminalDoor = GameObject.FindGameObjectsWithTag("TerminalDoor");
        escapeDoor = GameObject.FindGameObjectsWithTag("EscapeDoor");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            inTrigger = true;
            Debug.Log(inTrigger);
           

        }
    }


    private void OpenDoor()
    {
        if(inTrigger == true)
        {
            if (Input.GetButtonDown("Interact"))
            {
                for (int i = 0; i < terminalDoor.Length; i++)
                {
                    terminalDoor[i].GetComponent<Collider>().enabled = true;
                }


            }

            if (gotKey == true && Input.GetButtonDown("Interact"))
            {

                for (int i = 0; i < escapeDoor.Length; i++)
                {
                    escapeDoor[i].GetComponent<Collider>().enabled = true;
                }


            }

        }
    }

   private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = false;
            Debug.Log(inTrigger);
        }
    }

    

    // Update is called once per frame
    void Update()
    {

        OpenDoor();


 



    }
}
