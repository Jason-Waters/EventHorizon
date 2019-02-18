using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCheck : MonoBehaviour
{
    public GameObject firstDoor;
    public GameObject inbetweenCheck;
    private Animator doorAnimator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = firstDoor.GetComponent<Animator>();
        
    }

    IEnumerator DoorWait()
    {
        inbetweenCheck.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3f);
        gameObject.GetComponent<Collider>().enabled = true;
    }

    private void CheckAnimationState()
    {
        if(doorAnimator.GetBool("playOpen") == false)
        {

            if (inbetweenCheck.GetComponent<Inbetween>().inTrigger)
            {
                StartCoroutine(DoorWait());
                firstDoor.GetComponent<Collider>().enabled = false;
            }

            
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (firstDoor.GetComponent<Collider>().enabled)
        {
            CheckAnimationState();
        }
    }
}
