using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
   private new Rigidbody2D rigidbody;

   private void Awake(){
       rigidbody =GetComponent<Rigidbody2D>();
   }

   private void OnCollisionEnter2D(Collision2D collision){
      if(collision.gameObject.layer == LayerMask.NameToLayer("Barrel"))
            Destroy(collision.gameObject);
       
   }
}
