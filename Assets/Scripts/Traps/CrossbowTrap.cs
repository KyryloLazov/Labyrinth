using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowTrap : MonoBehaviour, ITriggerable
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float delayBetweenShots;
    [SerializeField] private int arrowAmount;

    public void TriggerTrap()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        for(int i = 0; i < arrowAmount; i++)
        {
            GameObject gameObject = Instantiate(arrowPrefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(delayBetweenShots);
        }
        
    }
}
