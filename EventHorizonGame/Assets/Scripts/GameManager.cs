using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public GameObject waypoints;
    public List<Vector3> waypointList;        
    public GameObject controlRoom;
    public GameObject terminal;
    public GameObject alien;
    public Transform spawnPoint;
    public AudioClip startingMusic;
    public AudioClip alienMusic;
    private AudioSource gm_audio;
    private bool musicChanged;





    private void Awake()
    {
        
        
        for(int i = 0;i < waypoints.transform.childCount; i++)
        {
            waypointList[i] = waypoints.transform.GetChild(i).transform.position;
        }
        gm_audio = gameObject.GetComponent<AudioSource>();

    }

    public void CheckSound()
    {
        if (gm_audio.isPlaying && terminal.GetComponent<TerminalScript>().count >= 1 && musicChanged == false)
        {
            gm_audio.clip = alienMusic;
            musicChanged = true;
            gm_audio.Play();
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



}
