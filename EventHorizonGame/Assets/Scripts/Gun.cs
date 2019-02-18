using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public LayerMask targetLayer;
    public LayerMask obstacleLayer;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public Camera fpsCam;
    public float fireRate = 2f;

    private float nextTimeToFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();

        }
    }


    private void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;

        
        
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range,targetLayer))
        {
            
            Stunned alien = hit.transform.GetComponent<Stunned>();
            if(alien != null)
            {
                alien.GetStun(true);
            }
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);


        }else if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, obstacleLayer))
        {
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);
        }
    }
}
