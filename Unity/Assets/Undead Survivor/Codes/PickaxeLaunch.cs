using System.Collections;
using UnityEngine;

public class PickaxeLaunch : MonoBehaviour
{
    [SerializeField] private GameObject pickaxePrefab;
    private Transform farmer;
    private Vector2 spawnPoint;
    [SerializeField] private float searchRadius;
    private void Start()
    {
        farmer = transform.parent;
        StartCoroutine(initPickaxe());
    }

    IEnumerator initPickaxe()
    {
        while (true)
        {
            Transform nearestEnemy = null;
            float nearestDistance = Mathf.Infinity;
            Collider2D[] hits = Physics2D.OverlapCircleAll(farmer.position, searchRadius);

            spawnPoint = transform.position;
            float distance;
            foreach (Collider2D hit in hits)
            {
                if (hit.CompareTag("Enemy"))
                {
                    distance = Vector2.Distance(farmer.position, hit.transform.position);
                    if (distance < nearestDistance)
                    {
                        nearestDistance = distance;
                        nearestEnemy = hit.transform;
                    }
                }
            }

            if (nearestEnemy != null)
            {
                GameObject spawnedPickaxe = Instantiate(pickaxePrefab, spawnPoint, Quaternion.identity);
                spawnedPickaxe.GetComponent<BoomerangMove>().Init(farmer, nearestEnemy);
            }
            
          
            yield return new WaitForSeconds(1f);
        }
    }
}   
