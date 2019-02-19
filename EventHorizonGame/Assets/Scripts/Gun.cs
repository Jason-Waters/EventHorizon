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
    public Transform gunEnd;
    public float fireRate = 2f;

    private float nextTimeToFire = 0f;
    private LineRenderer laserLine;
    private AudioSource gunAudio;
    

    // Start is called before the first frame update
    void Start()
    {
        laserLine = gameObject.GetComponent<LineRenderer>();
        
        gunAudio = gameObject.GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            if (Time.timeScale == 1)
            {
                Shoot();
            }

        }
    }

    private void CreateWeaponTracer(Vector3 fromPosition,Vector3 targetPosition)
    {
        Vector3 dir = (targetPosition - fromPosition).normalized;
        
    }

    private IEnumerator ShotEffect()
    {
        gunAudio.Play();
        laserLine.enabled = true;
        yield return new WaitForSeconds(.07f);
        laserLine.enabled = false;

    }


    private void Shoot()
    {

        muzzleFlash.Play();
        RaycastHit hit;
        laserLine.SetPosition(0, gunEnd.position);


        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range,targetLayer))
        {
            muzzleFlash.Play();
            StartCoroutine(ShotEffect());
            laserLine.SetPosition(1, hit.point);
            Stunned alien = hit.transform.GetComponent<Stunned>();
            if(alien != null)
            {
                alien.GetStun(true);
            }
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);


        }else if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, obstacleLayer))
        {
            muzzleFlash.Play();
            StartCoroutine(ShotEffect());
            laserLine.SetPosition(1, hit.point);

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);
        }
    }
}
