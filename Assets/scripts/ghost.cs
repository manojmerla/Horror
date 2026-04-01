using UnityEngine;
using System.Collections;

public class ghost : MonoBehaviour
{
    public GameObject photoObject;     // The photo object to hide/show
    public string playerTag = "Player";

    private Coroutine hideCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if (hideCoroutine != null)
                StopCoroutine(hideCoroutine);

            hideCoroutine = StartCoroutine(HideAfterDelay(0.55f));
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

            photoObject.SetActive(true);
        }
    }

    private IEnumerator HideAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        photoObject.SetActive(false);
    }
}
