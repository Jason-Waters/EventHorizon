using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject waypoints;
    public List<Vector3> waypointList;
    public GameObject alien;
    public Transform spawnPoint;

    private void Awake()
    {
        
        
        for(int i = 0;i < waypoints.transform.childCount; i++)
        {
            waypointList[i] = waypoints.transform.GetChild(i).transform.position;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
