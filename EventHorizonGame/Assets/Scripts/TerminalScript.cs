using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalScript : MonoBehaviour
{
    private bool inTrigger;
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
        }
    }

   private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = false;
        }
    }

    

    // Update is called once per frame
    void Update()
    {

        if (inTrigger = true && Input.GetButtonDown("Interact"))
        {
            for(int i = 0;i < terminalDoor.Length; i++)
            {
                terminalDoor[i].GetComponent<Collider>().enabled = true;
            }
            

        }

        if (inTrigger == true && gotKey == true && Input.GetButtonDown("Interact"))
        {

            for(int i = 0;i < escapeDoor.Length; i++)
            {
                escapeDoor[i].GetComponent<Collider>().enabled = true;
            }
        

        }



    }
}
