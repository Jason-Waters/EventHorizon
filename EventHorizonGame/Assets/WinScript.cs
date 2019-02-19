using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{

    public Animator animator;
    public GameObject winImage;
    private int levelToLoad;
    public Image fadeScreen;
            

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winImage.SetActive(true);
            gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(AudioLength());
        }
    }

    IEnumerator AudioLength()
    {
        yield return new WaitForSeconds(gameObject.GetComponent<AudioSource>().clip.length * 2);
        FadeToLevel(3);
    }

    IEnumerator ClipLength()
    {

        yield return new WaitForSeconds(2f);
        
        OnFadeComplete();
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
        StartCoroutine(ClipLength());
    }

    public void OnFadeComplete()
    {

        SceneManager.LoadScene(3);
    }

}
