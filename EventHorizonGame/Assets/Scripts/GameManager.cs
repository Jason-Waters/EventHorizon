using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public GameObject waypoints;
    public List<Vector3> waypointList;
    public GameObject alien;
    public Transform spawnPoint;
    private Collider cardTrigger;    
    public GameObject controlRoom;
    

    

    private void Awake()
    {
        
        
        for(int i = 0;i < waypoints.transform.childCount; i++)
        {
            waypointList[i] = waypoints.transform.GetChild(i).transform.position;
        }
    }


    
    private void TurnOnNavMesh(bool gotCard)
    {
        if (gotCard)
        {
            controlRoom.GetComponent<NavMeshObstacle>().enabled = false;
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
