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
    public GameObject terminal;
    

    

    private void Awake()
    {
        
        
        for(int i = 0;i < waypoints.transform.childCount; i++)
        {
            waypointList[i] = waypoints.transform.GetChild(i).transform.position;
        }
    }


    
    public void TurnOnNavMesh(bool gotCard)
    {
        if (gotCard)
        {
            controlRoom.GetComponent<NavMeshObstacle>().enabled = false;
            terminal.GetComponent<TerminalScript>().gotKey = true;
        }
    }

    public void SpawnAlien()
    {
        Instantiate(alien, spawnPoint.position, spawnPoint.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
       // SpawnAlien();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
