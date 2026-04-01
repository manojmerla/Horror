
using UnityEngine;
using TMPro;

public class FlashLight : MonoBehaviour
{
    public Light flashLightLight;
    public GameObject flashLightModel;
    public KeyCode toggleKey = KeyCode.F;
    public TextMeshProUGUI pressF;

    private bool isOn = true;
    private bool hintCleared = false;

    void OnEnable()
    {
        flashLightLight.enabled = true;
        if (flashLightModel != null)
        {
            flashLightModel.SetActive(true);
        }
        if (pressF != null)
        {
            pressF.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            isOn = !isOn;
            flashLightLight.enabled = isOn;

            if (!hintCleared && pressF != null)
            {
                pressF.gameObject.SetActive(false);
                hintCleared = true;
            }
        }
    }
}
