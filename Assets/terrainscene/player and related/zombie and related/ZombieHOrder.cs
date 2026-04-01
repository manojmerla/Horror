using UnityEngine;

public class ZombieHorder : MonoBehaviour
{
    public GameObject[] zombiePrefabs;
    public Transform player;
    public float spawnRate = 2f;
    public float spawnDistance = 30f;

    Terrain terrain;

    void Start()
    {
        terrain = Terrain.activeTerrain;
        InvokeRepeating("SpawnZombie", 0f, spawnRate);
    }

    void SpawnZombie()
    {
        Vector2 circle = Random.insideUnitCircle.normalized * spawnDistance;
        Vector3 pos = new Vector3(circle.x, 0f, circle.y) + player.position;
        pos.y = terrain.SampleHeight(pos);

        int index = Random.Range(0, zombiePrefabs.Length);
        GameObject zombie = Instantiate(zombiePrefabs[index], pos, Quaternion.identity);
        zombie.GetComponent<Zombie>().player = player;
    }
}
