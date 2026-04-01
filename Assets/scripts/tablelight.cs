using UnityEngine;
using TMPro;

public class FlashlightPickup : MonoBehaviour
{
    public GameObject playerFlashLight;
    public GameObject tableFlashLight;
    public TextMeshProUGUI interactUI;
    public Transform cameraTransform;
    public float interactDistance = 2f;
    public KeyCode interactKey = KeyCode.E;

    private bool canPickup = false;

    void Start()
    {
        playerFlashLight.SetActive(false);
        interactUI.gameObject.SetActive(false);
    }

    void Update()
    {
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                interactUI.gameObject.SetActive(true);
                canPickup = true;

                if (Input.GetKeyDown(interactKey))
                {
                    playerFlashLight.SetActive(true);
                    Destroy(tableFlashLight);
                }
            }
        }
        else
        {
            interactUI.gameObject.SetActive(false);
            canPickup = false;
        }
    }
}
