using UnityEngine;

public class MotionSensor : MonoBehaviour
{
    public Light targetLight;
    public Renderer bulbRenderer;
    public Material onMaterial;
    public Material offMaterial;

    public AudioSource clickSource;
    public AudioClip clickClip;

    public AudioSource buzzSource;
    public AudioClip buzzClip;

    public float delayBeforeOff = 5f;

    private bool playerInside = false;
    private float timer = 0f;
    private bool isLightOn = false;

    void Start()
    {
        SetLightState(false);
    }

    void Update()
    {
        if (!playerInside && isLightOn)
        {
            timer += Time.deltaTime;

            if (timer >= delayBeforeOff)
            {
                SetLightState(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            SetLightState(true);
            timer = 0f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            timer = 0f;
        }
    }

    void SetLightState(bool state)
    {
        isLightOn = state;
        targetLight.enabled = state;
        bulbRenderer.material = state ? onMaterial : offMaterial;

        if (clickSource && clickClip)
        {
            clickSource.PlayOneShot(clickClip);
        }

        if (buzzSource)
        {
            if (state && buzzClip)
            {
                buzzSource.clip = buzzClip;
                buzzSource.Play();
            }
            else
            {
                buzzSource.Stop();
            }
        }
    }
}
