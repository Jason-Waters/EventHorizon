using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    private GameObject g_manager;
    private int currentWP = 0;
    private NavMeshAgent navMesh;
    private List<Vector3> waypoints;
    private bool traversingLink;
    private OffMeshLinkData currentLink;
    
    // Start is called before the first frame update
    void Start()
    {
        g_manager = GameObject.FindGameObjectWithTag("GameController");
        waypoints = g_manager.GetComponent<GameManager>().waypointList;
        Debug.Log(waypoints.Capacity);
        for(int i = 0; i < waypoints.Capacity; i++)
        {
            Debug.Log(waypoints[i]);
        }

        navMesh = gameObject.GetComponent<NavMeshAgent>();
        navMesh.SetDestination(waypoints[currentWP]);
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentWP);
        if(navMesh.remainingDistance == 0 && !navMesh.pathPending)
        {
            currentWP++;
            if(currentWP >= waypoints.Capacity)
            {
                currentWP = 0;
            }
            navMesh.SetDestination(waypoints[currentWP]);
        }

        if (navMesh.isOnOffMeshLink)
        {
            OffMesh();
        }
    }

    private void OffMesh()
    {
        if (!traversingLink)
        {

            currentLink = navMesh.currentOffMeshLinkData;
            traversingLink = true;

        }


        
        Vector3 endPos = new Vector3(currentLink.endPos.x, navMesh.transform.position.y, currentLink.endPos.z);

        var endRotation = Quaternion.LookRotation(endPos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, endRotation, (navMesh.speed / 1.5f) * Time.deltaTime);
        transform.position = Vector3.MoveTowards(navMesh.transform.position, endPos, (navMesh.speed /1.5f) * Time.deltaTime);
        
        
        if (navMesh.transform.position == endPos)
        {
            traversingLink = false;
            navMesh.CompleteOffMeshLink();
            navMesh.isStopped = false;
        }
    }
}
