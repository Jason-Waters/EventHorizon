using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalScript : MonoBehaviour
{
    private bool inTrigger = false;
    private GameObject[] terminalDoor;
    public bool gotKey = false;
    private GameObject[] escapeDoor;
    private int count = 0;
    private GameObject g_manager;
    // Start is called before the first frame update
    void Start()
    {
        terminalDoor = GameObject.FindGameObjectsWithTag("TerminalDoor");
        escapeDoor = GameObject.FindGameObjectsWithTag("EscapeDoor");
        g_manager = GameObject.FindGameObjectWithTag("GameController");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            inTrigger = true;
            
           

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
                    if(count == 0)
                    {
                        g_manager.GetComponent<GameManager>().SpawnAlien();
                        count++;
                    }

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
            
        }
    }

    

    // Update is called once per frame
    void Update()
    {

        OpenDoor();


 



    }
}
