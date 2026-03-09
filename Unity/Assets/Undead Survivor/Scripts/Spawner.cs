using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    float timer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1f)
        {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }
}
