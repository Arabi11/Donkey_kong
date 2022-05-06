using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUP : MonoBehaviour
{
    [SerializeField] private GameObject [] prrefab;

    [SerializeField] private float currentTimeToSpawn;

    [SerializeField]private float timeToSpawn;
    
   
    


    private void Start(){

        
        
    }

    public void Update(){
        if(currentTimeToSpawn > 0){
            currentTimeToSpawn -= Time.deltaTime;
        }
        else{
            Spawn();
            currentTimeToSpawn = timeToSpawn;
        }
    }
    private void Spawn(){
        
        int numOfObjects  = Random.Range(0,prrefab.Length);
        Instantiate(prrefab[numOfObjects], transform.position, Quaternion.identity);
        
        
        
    }
    
}

