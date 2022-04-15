using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prrefab;
    [SerializeField] private float minTime =50f;
    [SerializeField] private float maxTime = 400f ;


    private void Start(){
        Spawn();
    }
    private void Spawn(){
        Instantiate(prrefab, transform.position, Quaternion.identity);
        Invoke(nameof(Spawn), Random.Range(minTime, maxTime));
        
    }
}
