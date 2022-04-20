using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
   private new Rigidbody2D rigidbody;
   private bool collided = false;
   

  

  
   [SerializeField] private float speed ;

   private void Awake(){
       rigidbody =GetComponent<Rigidbody2D>();
        //rigidbody.AddForce(transform.right*-1*Random.Range(0.5f, 2f), ForceMode2D.Impulse );
      
   }

   private void OnCollisionEnter2D(Collision2D collision){
      
      if(!collided){
         rigidbody.AddForce(collision.transform.right*Random.Range(0.5f, 2f), ForceMode2D.Impulse );
         collided = true;
      }
      
      Physics2D.IgnoreLayerCollision(7,7);
       
      }
    
    }
     


  
   
   
  

   
   

   

