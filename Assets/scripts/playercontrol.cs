using UnityEngine;

public class playercontrol : MonoBehaviour
{
    public float movespeed = 5f;
    private CharacterController controller;
    public float jumpforce = 5f;
    private Transform camera;
    private float yVelocity;
    public float gravity = -9.81f;

    private bool isJumping;

    public AudioSource walkAudioSource; // Add this in Inspector

    void Start()
    {
        controller = GetComponent<CharacterController>();
        camera = Camera.main.transform;

        if (walkAudioSource != null)
        {
            walkAudioSource.loop = true; // Make sure it's looped
        }
    }

    void Update()
    {
        float movementx = Input.GetAxis("Horizontal");
        float movementz = Input.GetAxis("Vertical");

        Vector3 movement = (camera.forward * movementz + camera.right * movementx);
        movement.y = 0f;
        movement = movement.normalized * movespeed;

        bool isMoving = new Vector3(movementx, 0, movementz).magnitude > 0.1f;

        if (controller.isGrounded)
        {
            if (isJumping)
            {
                isJumping = false;
            }

            yVelocity = -1f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpforce;
                isJumping = true;
            }

            // Handle footstep sound
            if (isMoving && !walkAudioSource.isPlaying)
            {
                walkAudioSource.Play();
            }
            else if (!isMoving && walkAudioSource.isPlaying)
            {
                walkAudioSource.Pause();
            }
        }
        else
        {
            yVelocity += gravity * Time.deltaTime;
            if (walkAudioSource.isPlaying) walkAudioSource.Pause();
        }

        movement.y = yVelocity;

        controller.Move(movement * Time.deltaTime);
    }
}
