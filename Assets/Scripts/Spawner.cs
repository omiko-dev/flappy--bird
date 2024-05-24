using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pipesPrefab;  // Changed to pipesPrefab to avoid confusion
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 2f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        if (pipesPrefab != null)
        {
            GameObject pipes = Instantiate(pipesPrefab, transform.position, Quaternion.identity);
            pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        }
        else
        {
            Debug.LogWarning("Pipes prefab is missing!");
        }
    }

}
