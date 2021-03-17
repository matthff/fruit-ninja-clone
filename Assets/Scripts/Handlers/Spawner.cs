using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] fruitsToSpawn;
    public GameObject bombPrefab;
    public Transform[] spawnPositions;

    float minTime = .3f;
    float maxTime = 1f;
    float minForce = 12f;
    float maxForce = 14f;


    void Start(){
        StartCoroutine(SpawnFruits());
    }

    IEnumerator SpawnFruits(){
        while(true){
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            GameObject randomFruit = fruitsToSpawn[Random.Range(0, fruitsToSpawn.Length)];
            GameObject objToSpawn = null; 
            int chance = Random.Range(0, 100);
            if(chance <= 10){
                objToSpawn = bombPrefab;
            }else{
                objToSpawn = randomFruit;
            }
            Transform spwPos = spawnPositions[Random.Range(0, spawnPositions.Length)];
            GameObject objSpawned = Instantiate(objToSpawn, spwPos.position, Random.rotation);
            objSpawned.GetComponent<Rigidbody2D>().AddForce(spwPos.transform.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);
            Destroy(objSpawned, 10f);
        }
    }
}
