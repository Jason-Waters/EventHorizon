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
        agent.speed = 6;
        agent.acceleration = 10;
    }



    void Update()
    {
        Move();

        CheckDistance();
        
    }
}
