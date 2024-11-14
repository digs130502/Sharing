using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawn : MonoBehaviour
{
    [SerializeField] GameObject fruit;
    [SerializeField] Vector2 spawnAreaSize = new Vector2(5, 2);
    [SerializeField] float spawnTime = 1.0f;
    private Vector2 spawnBounds;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruit());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnFruit()
    {

        while (true)
        {
            // Wait for spawn time before spawning another fruit
            yield return new WaitForSeconds(spawnTime);

            // Random position within the defined spawn area
            Vector2 spawnPosition = (Vector2)transform.position + new Vector2(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2)
            );

            // Instantiate the fruite at the spawn position
            GameObject spawnedFruit = Instantiate(fruit, spawnPosition, Quaternion.identity);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
