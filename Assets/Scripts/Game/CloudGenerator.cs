using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CloudGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] clouds;
    [SerializeField] float spawnInterval;
    [SerializeField] float cloudLifetime;
    [SerializeField] GameObject endPoint;
    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        Prewarm();
        Invoke("AttemptSpawn", spawnInterval);
    }

    private void SpawnCloud(Vector3 startPos)
    {
        int randomIndex = UnityEngine.Random.Range(0, clouds.Length);
        GameObject cloud = Instantiate(clouds[randomIndex]);
        float startY = UnityEngine.Random.Range(startPos.y + 3f, startPos.y + 6f);
        cloud.transform.position = new Vector3(startPos.x, startY, startPos.z);
        float scale = UnityEngine.Random.Range(0.25f, 0.75f);
        cloud.transform.localScale = new Vector2(scale, scale);
        float speed = UnityEngine.Random.Range(0.001f, 0.005f) /1.25f ;
        cloud.GetComponent<CloudScript>().StartFloating(speed, endPoint.transform.position.x);
        Destroy(cloud, cloudLifetime);
    }

    private void AttemptSpawn()
    {
        SpawnCloud(startPos);
        Invoke("AttemptSpawn", spawnInterval);
    }

    private void Prewarm()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 spawnPos = startPos + Vector3.right * (i * 2);
            SpawnCloud(spawnPos);
        }
    }

}