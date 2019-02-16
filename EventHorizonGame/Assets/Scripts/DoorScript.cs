using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public Animator anim;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Alien"))
        {
            anim.SetBool("playOpen", true);
            anim.SetBool("isOpen", false);
            anim.SetBool("isClosed", true);
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Alien"))
        {

            anim.SetBool("isOpen", true);
            anim.SetBool("playOpen", false);



        }
    }
}
