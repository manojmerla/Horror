using UnityEngine;
using TMPro;

public class ScaryPainting : MonoBehaviour
{
    public GameObject normalPainting; // Reference to the painting
    public TextMeshProUGUI interactUI; // "Press E" UI text
    public Transform cameraTransform; // Player camera
    public float interactDistance = 5f;
    public KeyCode interactKey = KeyCode.E;

    private bool canInteract = true;

    void Start()
    {
        interactUI.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!canInteract)
        {
            interactUI.gameObject.SetActive(false);
            return;
        }

        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            Debug.Log("Hit: " + hit.collider.name); // 👈 Shows what object is hit

            if (hit.collider.gameObject == normalPainting)
            {
                interactUI.gameObject.SetActive(true);

                if (Input.GetKeyDown(interactKey))
                {
                    Destroy(normalPainting);
                    // Optional: scary effect here
                }
            }
            else
            {
                interactUI.gameObject.SetActive(false);
            }
        }
        else
        {
            interactUI.gameObject.SetActive(false);
        }
    }
}
