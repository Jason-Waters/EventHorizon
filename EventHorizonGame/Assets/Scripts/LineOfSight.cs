using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{

    public LayerMask environment;
    public LayerMask player;
    private Transform target;
    private bool inLineOfSight;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    bool InFront()
    {
        Vector3 directionToTarget = transform.position - target.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);

        if(Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
        {
            Debug.DrawLine(transform.position, target.position, Color.green);
            return true;
        }

        Debug.DrawLine(transform.position, target.position, Color.yellow);
        return false;
    }


    



    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Linecast(transform.position,target.position, out hit, environment))
        {
            inLineOfSight = false;
        }
        else
        {
            inLineOfSight = true;
        }
    }
}
