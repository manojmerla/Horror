using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        Vector3 direction = player.position - transform.position;

        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = lookRotation;
        }
    }
}
