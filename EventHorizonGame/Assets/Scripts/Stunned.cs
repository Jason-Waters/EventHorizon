using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stunned : MonoBehaviour
{
    
    public float stunTime = 5f;


    public void GetStun(bool shot)
    {
        
        if (shot)
        {
            Debug.Log(gameObject.GetComponent<Immune>().enabled);
            CheckImmunity();

        }


    }

    IEnumerator Unstun()
    {
        yield return new WaitForSeconds(stunTime);
        gameObject.GetComponent<NavMeshAgent>().isStopped = false;        

    }

    private void CheckImmunity()
    {
        if (gameObject.GetComponent<Immune>().enabled)
        {
            Debug.Log("Immune");
        }
        else
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            gameObject.GetComponent<AlienController>().UpdateState(3);
            StartCoroutine(Unstun());
        }


    }
}
