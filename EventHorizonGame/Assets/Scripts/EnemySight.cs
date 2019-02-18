using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    private float timer = 0;
    public float heightMultiplier;
    public float sightDist = 10f;
    private int setState = 2;
    private Collider player;
    public GameObject g_manager;
    // Start is called before the first frame update
    void Start()
    {
        heightMultiplier = 0;
        player = GameObject.FindWithTag("Player").GetComponent<Collider>();
        
    }


    void Investigate()
    {
        timer += Time.deltaTime;
        

        //Front LOS
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, transform.forward * sightDist, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right).normalized * sightDist*.5f, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right/2).normalized * sightDist * .75f, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized * sightDist *.5f, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right/2).normalized * sightDist * .75f, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right / 4).normalized * sightDist * .75f, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right / 4).normalized * sightDist * .75f, Color.green);


        //Back LOS
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, transform.forward * sightDist, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (-transform.forward + transform.right).normalized * sightDist * .5f, Color.blue);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (-transform.forward + transform.right / 2).normalized * sightDist * .5f, Color.blue);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (-transform.forward - transform.right).normalized * sightDist * .5f, Color.blue);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (-transform.forward - transform.right / 2).normalized * sightDist * .5f, Color.blue);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (-transform.forward - transform.right / 4).normalized * sightDist * .5f, Color.blue);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (-transform.forward + transform.right / 4).normalized * sightDist * .5f, Color.blue);




        DrawFrontRays();
        DrawBackRays();





    }

    private void DrawBackRays()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, -transform.forward, out hit, sightDist * .5f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("hit player");
                gameObject.GetComponent<AlienController>().UpdateState(setState);
            }
        }

        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (-transform.forward + (transform.right / 4)).normalized, out hit, sightDist * .5f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("hit player");
                gameObject.GetComponent<AlienController>().UpdateState(setState);
            }
        }

        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (-transform.forward + transform.right).normalized, out hit, sightDist * .5f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("hit player");
                gameObject.GetComponent<AlienController>().UpdateState(setState);
            }
        }

        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (-transform.forward + (transform.right / 2)).normalized, out hit, sightDist * .5f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("hit player");
                gameObject.GetComponent<AlienController>().UpdateState(setState);
            }
        }

        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (-transform.forward - transform.right).normalized, out hit, sightDist * .5f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("hit player");
                gameObject.GetComponent<AlienController>().UpdateState(setState);
            }
        }

        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (-transform.forward - (transform.right / 2)).normalized, out hit, sightDist * .5f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("hit player");
                gameObject.GetComponent<AlienController>().UpdateState(setState);
            }
        }

        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (-transform.forward - (transform.right / 4)).normalized, out hit, sightDist * .5f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("hit player");
                gameObject.GetComponent<AlienController>().UpdateState(setState);
            }
        }


    }

    private void DrawFrontRays()
    {
        RaycastHit hit;
        //Front LOS
        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, transform.forward, out hit, sightDist))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("hit player");
                gameObject.GetComponent<AlienController>().UpdateState(setState);
            }
        }

        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward + (transform.right / 4)).normalized, out hit, sightDist * .75f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("hit player");
                gameObject.GetComponent<AlienController>().UpdateState(setState);
            }
        }

        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right).normalized, out hit, sightDist * .5f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("hit player");
                gameObject.GetComponent<AlienController>().UpdateState(setState);
            }
        }

        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward + (transform.right / 2)).normalized, out hit, sightDist * .75f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("hit player");
                gameObject.GetComponent<AlienController>().UpdateState(setState);
            }
        }

        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized, out hit, sightDist * .5f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("hit player");
                gameObject.GetComponent<AlienController>().UpdateState(setState);
            }
        }

        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward - (transform.right / 2)).normalized, out hit, sightDist * .75f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("hit player");
                gameObject.GetComponent<AlienController>().UpdateState(setState);
            }
        }

        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward - (transform.right / 4)).normalized, out hit, sightDist * .75f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("hit player");
                gameObject.GetComponent<AlienController>().UpdateState(setState);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        Investigate();
    }
}
