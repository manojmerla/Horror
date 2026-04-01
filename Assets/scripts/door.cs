using UnityEngine;
using TMPro;
using System.Collections;

public class Door : MonoBehaviour
{
    public Transform doorHinge;
    public TextMeshProUGUI interactUI;
    public Transform cameraTransform;
    public float interactDistance = 2f;
    public KeyCode interactKey = KeyCode.E;
    public float rotateSpeed = 3f;

    private bool isOpen = false;
    private bool isMoving = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        closedRotation = doorHinge.localRotation;
        openRotation = Quaternion.Euler(0, -90f, 0) * closedRotation;
        interactUI.gameObject.SetActive(false);
    }

    void Update()
    {
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            Debug.Log("Hit: " + hit.transform.name);

            if (hit.collider == GetComponent<Collider>())
            {
                interactUI.gameObject.SetActive(true);

                if (Input.GetKeyDown(interactKey) && !isMoving)
                {
                    isOpen = !isOpen;
                    StopAllCoroutines();
                    StartCoroutine(RotateDoor(isOpen ? openRotation : closedRotation));
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

    IEnumerator RotateDoor(Quaternion targetRotation)
    {
        isMoving = true;

        while (Quaternion.Angle(doorHinge.localRotation, targetRotation) > 0.1f)
        {
            doorHinge.localRotation = Quaternion.Slerp(doorHinge.localRotation, targetRotation, Time.deltaTime * rotateSpeed);
            yield return null;
        }

        doorHinge.localRotation = targetRotation;
        isMoving = false;
    }
}
