using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public LayerMask targetLayer;

    public Camera fpsCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();

        }
    }


    private void Shoot()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range,targetLayer))
        {
            
            Stunned alien = hit.transform.GetComponent<Stunned>();
            if(alien != null)
            {
                alien.GetStun(true);
            }
        }
    }
}
