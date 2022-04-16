using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
   private new Rigidbody2D rigidbody;
   private bool collided = false;
   private Vector2 direction;

  

  
   [SerializeField] private float speed = Random.Range(0.175f, 6f);

   private void Awake(){
       rigidbody =GetComponent<Rigidbody2D>();
      
   }

   private void Start(){
      direction.x = Random.Range(-100f,0);
      rigidbody.AddForce(direction);
   }

   private void OnCollisionEnter2D(Collision2D collision){
      if(!collided){
         rigidbody.AddForce(collision.transform.right*speed, ForceMode2D.Impulse );
         collided = true;
      }
      
      Physics2D.IgnoreLayerCollision(7,7);
       
   }

        
            
            
        

        
       
    }
     


  
   
   
  

   
   

   

