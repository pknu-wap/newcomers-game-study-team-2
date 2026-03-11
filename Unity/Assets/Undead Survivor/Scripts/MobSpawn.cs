using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy;
    private float spawnInterval = 0.5f;


    void Awake()
    {
        StartCoroutine(MobSpawnRoutine());
    }

    IEnumerator MobSpawnRoutine()
    {
        while(true)
        {
            Vector2 playerPos = GameManager.instance.player.transform.position;

            Vector2 spawnOffset = Random.insideUnitCircle.normalized * 5f;

            Instantiate(Enemy, playerPos + spawnOffset, Quaternion.identity);
            
            yield return new WaitForSeconds(spawnInterval);

        }
    }
}
