using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSelector : MonoBehaviour
{
    public void TurnOnSelector()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void TurnOffSelector()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

}
