using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Immune : MonoBehaviour
{
    public float immunityTime = 9f;


    private void OnEnable()
    {
        Debug.Log("Immune enabled");
        StartCoroutine(RemoveImmunity());
    }

    private void Update()
    {
  

       
    }

    IEnumerator RemoveImmunity()
    {
        Debug.Log("Inside RemoveImmunity");
        yield return new WaitForSeconds(immunityTime);
        gameObject.GetComponent<Immune>().enabled = false;
    }

  




}
