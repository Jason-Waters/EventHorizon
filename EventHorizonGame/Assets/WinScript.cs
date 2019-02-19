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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winImage.SetActive(true);
            gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine("AudioLength");
        }
    }

    IEnumerator AudioLength()
    {
        yield return new WaitForSeconds(gameObject.GetComponent<AudioSource>().clip.length);
        FadeToLevel(3);
    }
 

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {

        SceneManager.LoadScene(3);
    }

}
