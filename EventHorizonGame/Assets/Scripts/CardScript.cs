using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{

    private GameObject g_manager;
    private bool gotCard = false;
    private bool inTrigger;
    public GameObject interactText;
    public GameObject cardPicture;
    public GameObject objectives;

    private void Start()
    {
        g_manager = GameObject.FindGameObjectWithTag("GameController");
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            inTrigger = true;
            Debug.Log("Intrigger");
            interactText.SetActive(true);
            
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && inTrigger)
        {
            interactText.SetActive(false);            
            gotCard = true;
            g_manager.GetComponent<GameManager>().TurnOnNavMesh(gotCard);
            cardPicture.SetActive(true);
            objectives.transform.GetChild(1).gameObject.SetActive(false);
            objectives.transform.GetChild(2).gameObject.SetActive(true);
            Destroy(gameObject);

        }
    }




}
