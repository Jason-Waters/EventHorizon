using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    private bool sawEnemy;
    private NavMeshAgent agent;
    private GameObject player;
    private GameObject g_manager;
    private bool traversingLink;
    private OffMeshLinkData currentLink;
    // Start is called before the first frame update
    void Start()
    {
        g_manager = GameObject.FindGameObjectWithTag("GameController");
        agent = gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        sawEnemy = true;

        AlienStats();
    }


    private void Move()
    {
        if (sawEnemy == true) {
            agent.SetDestination(player.transform.position);
        }
    }
    

    private void CheckDistance()
    {
        if (Vector3.Distance(agent.transform.position, player.transform.position) > 20)
        {
            gameObject.GetComponent<AlienController>().UpdateState(1);
        }
    }

    private void AlienStats()
    {
        agent.speed = 10;
        agent.acceleration = 15;
    }
    private void OffMesh()
    {
        if (!traversingLink)
        {
            Debug.Log("Inside OffMeshLink");

            currentLink = agent.currentOffMeshLinkData;
            traversingLink = true;

        }



        Vector3 endPos = new Vector3(currentLink.endPos.x, agent.transform.position.y, currentLink.endPos.z);

        var endRotation = Quaternion.LookRotation(endPos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, endRotation, (agent.speed * 2) * Time.deltaTime);
        transform.position = Vector3.MoveTowards(agent.transform.position, endPos, (agent.speed / 1.5f) * Time.deltaTime);


        if (agent.transform.position == endPos)
        {
            traversingLink = false;
            agent.CompleteOffMeshLink();
            agent.isStopped = false;
        }
    }



    void Update()
    {
        Move();

        if (agent.isOnOffMeshLink)
        {
            
            OffMesh();
        }

        CheckDistance();
        
    }
}
