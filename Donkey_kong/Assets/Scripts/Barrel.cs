using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
   private new Rigidbody2D rigidbody;
   private bool collided = false;
   

  

  
   [SerializeField] private float speed = Random.Range(0.175f, 6f);

   private void Awake(){
       rigidbody =GetComponent<Rigidbody2D>();
       
      
   }

   private void OnCollisionEnter2D(Collision2D collision){
      if(!collided){
         rigidbody.AddForce(collision.transform.right*speed, ForceMode2D.Impulse );
         collided = true;
      }
      
      Physics2D.IgnoreLayerCollision(7,7);
       
   }

/**
  private void OnTriggerEnter2D(Collider2D collider){
     if(collider.gameObject.CompareTag("Player")){
        if(!Movement.instance.checkTheToe()&&collider.GetType() == typeof(CapsuleCollider2D)){

          
            ScoreManager.instance.AddJumpPoint();
            
            
        }
        else {
           ScoreManager.instance.AddPoint();
            
        }
        
     }
     
             
        }**/

        
            
            
        

        
       
    }
     


  
   
   
  

   
   

   

