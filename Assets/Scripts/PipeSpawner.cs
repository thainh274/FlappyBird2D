using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2f;
    public float heightRange = 1f;
    public bool enableSpawn; // This variable is used to control the spawning of pipes

    void Start()
    {
        enableSpawn = false;
        // after 1 second, start spawning pipes every spawnRate seconds
        InvokeRepeating(nameof(SpawnPipe), 1f, spawnRate);
    }

    private void SpawnPipe()
    {
        if (enableSpawn)
        {
            // Calculate a random height for the pipe
            float randomHeight = Random.Range(-heightRange, heightRange);
            // Create a new pipe at the specified position
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + randomHeight, 0);
            Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
