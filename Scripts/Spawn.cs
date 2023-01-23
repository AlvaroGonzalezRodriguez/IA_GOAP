using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject alienPrefab;
    public int numAliens;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numAliens; i++)
        {
            Instantiate(alienPrefab, this.transform.position, Quaternion.identity);
        }

        Invoke("SpawnAlien", 5);
    }

    void SpawnAlien()
    {
        Instantiate(alienPrefab, this.transform.position, Quaternion.identity);
        Invoke("SpawnAlien", Random.Range(5, 10));
    }

}
