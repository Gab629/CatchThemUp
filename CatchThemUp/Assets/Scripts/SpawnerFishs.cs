using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFishs : MonoBehaviour
{

    public GameObject smallEnnemies;
    private float spawnSmallInterval = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnnemies(spawnSmallInterval, smallEnnemies));
    }

    private IEnumerator spawnEnnemies(float interval, GameObject ennemy)
    {
        yield return new WaitForSeconds(interval);
        Vector2 randomPos = new Vector2(Random.Range(-10f, 10f), Random.Range(-0.1f, -6f));
        float distance = Vector2.Distance(transform.position, randomPos);

        if (distance >= 6f)
        {
            Instantiate(ennemy, randomPos, Quaternion.identity);
        }

        StartCoroutine(spawnEnnemies(interval, ennemy));

    }
}
