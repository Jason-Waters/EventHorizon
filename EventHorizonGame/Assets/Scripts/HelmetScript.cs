using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelmetScript : MonoBehaviour
{        
    public Animator helmAnim;
    public Animator hudAnim;
    public GameObject hud;
    

    // Start is called before the first frame update
    void Start()
    {
        helmAnim.SetBool("playClose", true);     
    }

    private void FixedUpdate()
    {
        if (helmAnim.GetBool("isClosed") && !helmAnim.GetBool("playClose"))
        {
            hudAnim.SetBool("helmClosed", true);
        }

    }







}
