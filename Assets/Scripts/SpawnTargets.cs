using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTargets : MonoBehaviour
{
    public int numTargets = 5000;
    public float xRange = 5000f;
    public float yRange = 5000f;

    public GameObject targetPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numTargets; i++)
        {
            // Random point from (-xRange, -yRange) to (xRange, yRange)
            Vector3 pos = new Vector3(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange), 1);

            Instantiate(targetPrefab, pos, Quaternion.identity);
        }
    }
}
