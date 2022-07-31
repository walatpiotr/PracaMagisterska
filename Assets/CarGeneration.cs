using Assets.Scripts.Pathing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGeneration : MonoBehaviour
{
    public GameObject vehiclePrefab;
    public float carSpawnFrequency;

    public bool generate;

    public float overlapRadius;

    public float timer;

    void FixedUpdate()
    {
        if (generate)
        {
            if (timer <= 0f)
            {
                TryToSpawn();
                timer = carSpawnFrequency;
            }
            timer -= Time.deltaTime;
        }
    }

    private void TryToSpawn()
    {
        Vector3 spawnPoint = this.transform.position;
        var hitCollider = Physics2D.OverlapCircle(spawnPoint, overlapRadius);
        if (hitCollider)
        {
            Debug.Log("Mam auto przy generatorze: " + hitCollider);
        }
        else
        {
            SpawnCar();
        }
    }

    private void SpawnCar()
    {
        var carInstantiated = Instantiate(vehiclePrefab, transform.position, Quaternion.identity);
        carInstantiated.GetComponent<FollowPath>().currentPath = this.gameObject.transform.parent.gameObject;
        carInstantiated.GetComponent<FollowPath>().target = this.gameObject.transform.parent.gameObject.GetComponent<Path>().path[0];
        carInstantiated.GetComponent<LightObserver>().lightWithEvents = this.gameObject.transform.parent.GetChild(0).GetChild(0).gameObject;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        //Gizmos.DrawSphere(transform.position, overlapRadius);
    }
}
