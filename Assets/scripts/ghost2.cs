using UnityEngine;
using System.Collections;

public class ghost2 : MonoBehaviour
{
    public GameObject photoObject;     // The photo object to hide/show
    public string playerTag = "Player";
    public AudioSource ghostAudio;     // Audio source to play the sound

    private Coroutine hideCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // Play sound immediately
            if (ghostAudio != null)
            {
                ghostAudio.Play();
                Debug.Log("Sound played immediately on trigger.");
            }
            else
            {
                Debug.LogWarning("No AudioSource assigned!");
            }

            // Start hide photo coroutine
            if (hideCoroutine != null)
                StopCoroutine(hideCoroutine);

            hideCoroutine = StartCoroutine(HideAfterDelay(10f));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if (hideCoroutine != null)
            {
                StopCoroutine(hideCoroutine);
                hideCoroutine = null;
            }

            photoObject.SetActive(true); // Reset photo on exit
        }
    }

    private IEnumerator HideAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (photoObject != null)
        {
            photoObject.SetActive(false);
            Debug.Log("photoObject set to false after 10 seconds.");
        }
    }
}
