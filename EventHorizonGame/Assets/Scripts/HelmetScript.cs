using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelmetScript : MonoBehaviour
{        
    public Animator helmAnim;
    public Animator hudAnim;
    public GameObject hud;
    public GameObject terminal;
    

    // Start is called before the first frame update
    void Start()
    {
        //helmAnim.SetBool("playClose", true);     
    }

    private void FixedUpdate()
    {
        //if (helmAnim.GetBool("isClosed") && !helmAnim.GetBool("playClose"))
        //{
        if (terminal.GetComponent<TerminalScript>().count >= 1)
        {
            hudAnim.SetBool("helmClosed", true);
        }
        //}

    }







}
