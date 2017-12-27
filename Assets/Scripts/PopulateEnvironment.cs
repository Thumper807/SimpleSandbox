using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateEnvironment : MonoBehaviour
{
    public GameObject[] PlantsToClone;
    public int VegetationDensitiy = 100;

	// Use this for initialization
	void Start ()
    {
        Vegetate();
	}
	
	private void Vegetate()
    {
        Debug.Log("Beginning Vegetation Phase.");
        Vector3 groundSize = Vector3.Scale(transform.localScale, transform.GetComponent<MeshFilter>().mesh.bounds.size);

        for (int i = 0; i < VegetationDensitiy; i++)
        {
            SpawnPlant(groundSize);
        }
        Debug.Log("Finished Vegetation Phase.");
    }

    private void SpawnPlant(Vector3 groundSize)
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        float randomX = Random.Range(-(groundSize.x / 2), groundSize.x / 2);
        float randomZ = Random.Range(-(groundSize.z / 2), groundSize.z / 2);
        Vector3 randomSpot = new Vector3(randomX, 0, randomZ);

        int failedAttempt = 0;
        while (failedAttempt < 100 && Physics.CheckSphere(randomSpot, 5.0f, 9))
        {
            Random.InitState(System.DateTime.Now.Millisecond);
            randomSpot.x = Random.Range(-(groundSize.x / 2), groundSize.x / 2);
            randomSpot.z = Random.Range(-(groundSize.z / 2), groundSize.z / 2);

            failedAttempt++;
        }

        if (failedAttempt == 100)
            Debug.Log("Gave up finding a random spot.");

        Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        GameObject plant = Instantiate(GetPlant(), randomSpot, randomRotation);
        plant.transform.SetParent(transform, true);
    }

    private GameObject GetPlant()
    {
        return PlantsToClone[Random.Range(0, PlantsToClone.Length)];
    }
}
