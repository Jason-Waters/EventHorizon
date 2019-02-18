using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelmetScript : MonoBehaviour
{
    private Vector3 startLocation;
    private Vector3 endLocation;
    public float closeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        startLocation = gameObject.GetComponent<RectTransform>().anchoredPosition3D;
        Debug.Log(startLocation);
        
        endLocation = startLocation;
        endLocation.y = -1000;
        Debug.Log(endLocation);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3.MoveTowards(startLocation, endLocation, closeSpeed*Time.deltaTime);
    }
}
