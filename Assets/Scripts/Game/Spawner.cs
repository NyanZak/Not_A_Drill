using System.Collections;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    public float initialDelay = 0.5f;
    public float spawnTimer = 6f;
    public float speedupTime = 20;
    public Transform[] pos;
    float timeCounter = 0f;
    public GameObject catPrefab;
    public GameObject tvPrefab;

    private void Start()
    {
        timeCounter = Time.time + speedupTime;
        StartCoroutine(SpawnObjectFirst());
    }

    IEnumerator SpawnObjectFirst()
    {
        yield return new WaitForSeconds(initialDelay);
        yield return new WaitUntil(() => velocity.pause == false);
        int index = Random.Range(0, 2);
        GameObject prefab;
        if (index == 0)
            prefab = catPrefab;
        else
            prefab = tvPrefab;
        Instantiate(prefab, pos[Random.Range(0, pos.Length)].position, transform.rotation);
        if (Time.time > timeCounter)
        {
            spawnTimer -= 0.25f;
            timeCounter = Time.time + 20;
        }
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(spawnTimer);
        yield return new WaitUntil(() => velocity.pause == false);
        int index = Random.Range(0, 2);
        GameObject prefab;
        if (index == 0)
            prefab = catPrefab;
        else
            prefab = tvPrefab;
        Instantiate(prefab, pos[Random.Range(0, pos.Length)].position, transform.rotation);

        if (Time.time > timeCounter)
        {
            spawnTimer -= 0.25f;
            timeCounter = Time.time + 20;
        }
        StartCoroutine(SpawnObject());
    }

}