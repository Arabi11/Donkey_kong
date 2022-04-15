using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
   private new Rigidbody2D rigidbody;
  
   [SerializeField] private float speed = Random.Range(0.5f, 1f);

   private void Awake(){
       rigidbody =GetComponent<Rigidbody2D>();
   }

   private void OnCollisionEnter2D(Collision2D collision){
      rigidbody.AddForce(collision.transform.right*speed, ForceMode2D.Impulse );
       
   }

  
   
   
  

   
   

   
}
