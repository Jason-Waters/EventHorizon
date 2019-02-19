using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{

    private GameObject g_manager;
    private bool gotCard = false;
    private bool inTrigger;
    public GameObject interactText;
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
            Destroy(gameObject);

        }
    }




}
