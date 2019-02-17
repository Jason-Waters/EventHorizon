using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent myNavMesh;
    AlienController state;
    public float lostDist = 15f;

    private void Awake()
    {
        myNavMesh = gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    void Start()
    {
        AlienStats();

        Move();

    }

    private void AlienStats()
    {
        myNavMesh.speed = 7;
        myNavMesh.acceleration = 10;
    }

    private void Move()
    {

        myNavMesh.SetDestination(player.transform.position);

        if (Vector3.Distance(gameObject.transform.position, player.transform.position) > lostDist)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<AlienController>().UpdateState(1);
        }
    }

    private void Update()
    {
        Move();

    }
}
