using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{

    
    public float viewRadius;
    public bool foundTarget;
    private GameObject g_manager;
    private int seeCount = 0;

    [Range(0,360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    [HideInInspector]
    public List<Transform> visibleTarget = new List<Transform>();


    
    
    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTarget();
        }
    }

    private void Start()
    {
        g_manager = GameObject.FindGameObjectWithTag("GameController");
        StartCoroutine("FindTargetsWithDelay", .2f);
    }

    private void FindVisibleTarget()
    {
     
        visibleTarget.Clear(); 
        Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for(int i = 0; i < targetInViewRadius.Length; i++)
        {
            Transform target = targetInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward,dirToTarget) < viewAngle / 2)
            {
                float disToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, disToTarget, obstacleMask))
                {
                    visibleTarget.Add(target);
                    foundTarget = true;                     
                    
                    
                }
               
            }
        }
        
        

    }

    private void Update()
    {
        CheckTarget();
    }

    private void CheckTarget()
    {
        if (visibleTarget.Count < 1)
        {
            foundTarget = false;
        }
        else
        {
            
            if (seeCount < 1)
            {
                Debug.Log("Iniside CheckTarget");
                gameObject.GetComponent<Patrol>().enabled = false;
                gameObject.GetComponent<Chase>().enabled = true;
                
            }
            seeCount++;
        }
  

    }
    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

}
