using System.Collections;
using UnityEngine;

public class PitchforkLaunch : MonoBehaviour
{
    [SerializeField] private GameObject pitchforkPrefab;
    private FarmerMovement farmerMovement;
    private Vector2 direction;
    private Vector2 spawnPoint;
    private void Start()
    {
        farmerMovement = GetComponentInParent<FarmerMovement>();
        StartCoroutine(initPitchfork());
    }

    IEnumerator initPitchfork()
    {
        while (true)
        {
            if (farmerMovement.MoveDirection != Vector2.zero)
            {
                direction = farmerMovement.MoveDirection;
            }
            else
            {
                direction = farmerMovement.LastDirection;
            }
            spawnPoint = transform.position;
            GameObject spawnedPithfork = Instantiate(pitchforkPrefab, spawnPoint, Quaternion.identity);
            spawnedPithfork.GetComponent<ProjectileMove>().Init(direction);
            yield return new WaitForSeconds(1f);
        }

    }
}
