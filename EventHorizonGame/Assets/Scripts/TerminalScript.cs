using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalScript : MonoBehaviour
{
    private bool inTrigger = false;
    private GameObject[] terminalDoor;
    public bool gotKey = false;
    private GameObject[] escapeDoor;
    public int count = 0;
    private GameObject g_manager;
    public GameObject interactText;
    public GameObject keyWarningText;
    public GameObject objectives;

    public float shakeMagnitude = 0.05f;
    public float shakeTime = .5f;
    public Camera mainCamera;
    private Vector3 cameraInitialPosition;
    


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


    void StartCameraShaking()
    {
        float cameraShakingOffsetX = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        float cameraShakingOffsetY = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        Vector3 cameraIntermediatePosition = mainCamera.transform.position;
        cameraIntermediatePosition.x += cameraShakingOffsetX;
        cameraIntermediatePosition.y += cameraShakingOffsetY;
        mainCamera.transform.position = cameraIntermediatePosition;
    }

    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        mainCamera.transform.position = cameraInitialPosition;


    }


    private void OpenDoor()
    {
        if(inTrigger == true)
        {
            interactText.SetActive(true);
            if (Input.GetButtonDown("Interact") && count < 1)
            {
                

                interactText.SetActive(false);
                gameObject.GetComponent<AudioSource>().Play();
                for (int i = 0; i < terminalDoor.Length; i++)
                {
                    terminalDoor[i].GetComponent<Collider>().enabled = true;
                    if(count == 0)
                    {

                        cameraInitialPosition = mainCamera.transform.position;
                        InvokeRepeating("StartCameraShaking", 0f, .005f);
                        Invoke("StopCameraShaking", shakeTime);

                        objectives.transform.GetChild(0).gameObject.SetActive(false);
                        objectives.transform.GetChild(1).gameObject.SetActive(true);
                        g_manager.GetComponent<GameManager>().SpawnAlien();
                        count++;
                        g_manager.GetComponent<GameManager>().CheckSound();
                    }

                }


            }

            if (gotKey == true && Input.GetButtonDown("Interact"))
            {
                interactText.SetActive(false);
                keyWarningText.SetActive(false);
                gameObject.GetComponent<AudioSource>().Play();
                for (int i = 0; i < escapeDoor.Length; i++)
                {
                    escapeDoor[i].GetComponent<Collider>().enabled = true;
                }
                objectives.transform.GetChild(2).gameObject.SetActive(false);
                objectives.transform.GetChild(3).gameObject.SetActive(true);


            }
            else if(gotKey == false && Input.GetButtonDown("Interact"))
            {
                interactText.SetActive(false);                
                keyWarningText.SetActive(true);
            }

        }
    }

   private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.SetActive(false);
            keyWarningText.SetActive(false);
            inTrigger = false;
            
        }
    }

    

    // Update is called once per frame
    void Update()
    {

        OpenDoor();


 



    }
}
