using UnityEngine;

public class Disparo_Spawner : MonoBehaviour
{
    public GameObject disparo;
    public float spawnTimer;
    public float spawnMax=10;
    public float spawnMin=5;
    void Start()
    {
        spawnTimer = Random.Range(spawnMin, spawnMax);
    }

    void Update()
    {
        spawnTimer-= Time.deltaTime;
        if (spawnTimer <= 0)
        {

            Instantiate(disparo, transform.position, Quaternion.identity);
            spawnTimer= Random.Range(spawnMin, spawnMax);
        }
    }
}
