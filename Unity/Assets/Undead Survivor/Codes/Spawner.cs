using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
public class Spawner : MonoBehaviour
{
    private float angle;
    private float x, y;
    private Vector2 direction;
    private Vector3 spawnPos;
    [SerializeField] private float radius = 8;
    [SerializeField] private GameObject enemyPrefab;
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {

        while (true)
        {
            angle = Random.Range(0f, Mathf.PI * 2f);
            direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            spawnPos = transform.position + (Vector3)direction * radius;
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(1.5f);
        }
    }
}
