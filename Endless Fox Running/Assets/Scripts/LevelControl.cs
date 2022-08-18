using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    public GameObject[] groundPrefabs;
    public float zSpawn = 0;
    public float groundLength=30;
    public int numberOfGround = 5;
    public Transform playerTransform;
    private List<GameObject> groundList = new List<GameObject>(); //aktif zeminler için
    void Start()
    {
        SpawnGround(0);
        for (int i = 0; i < groundPrefabs.Length; i++)
        {

            SpawnGround(Random.Range(1, groundPrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z > zSpawn - (numberOfGround * groundLength)) 
        {
            SpawnGround(Random.Range(1, groundPrefabs.Length));
            DeleteGround();
        }
    }
    public void SpawnGround(int groundIndex)
    {
        GameObject go =  Instantiate(groundPrefabs[groundIndex],transform.forward * zSpawn,transform.rotation);
        groundList.Add(go);
        zSpawn += groundLength;
    }
    private void DeleteGround()
    {
        Destroy(groundList[0]);
        groundList.RemoveAt(0);
    }
}
