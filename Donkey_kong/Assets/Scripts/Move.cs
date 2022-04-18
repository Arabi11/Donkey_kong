using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    
    Renderer rend;
    Color c;

    void Start(){
        rend = GetComponent<Renderer>();
        c = rend.material.color;
    }

    void OnTriggerEnter2D (Collider2D col){
        if(col.gameObject.CompareTag("Shrooms")){
            ScoreManager.instance.AddPoint(50);
            StartCoroutine("GetInvulnerable");
            Destroy(col.gameObject);
        }
        if(col.gameObject.CompareTag("HGH")){
            StartCoroutine("SpeedMan");
            Destroy(col.gameObject);
        }
    }
   
  
   
   IEnumerator GetInvulnerable(){
       Physics2D.IgnoreLayerCollision(7,8,true);
       c.a = 0.5f;
       rend.material.color = c;
       yield return new WaitForSeconds(5f);
       
       
       Physics2D.IgnoreLayerCollision(7,8,false);
      // FindObjectOfType.
       c.a =1f;
       rend.material.color =c;

   }

   IEnumerator SpeedMan(){

       float y = c.g ;
       c.g =5f;
       rend.material.color = c;
       float x = gameObject.GetComponent<Movement>().getMoveSpeed();
        gameObject.GetComponent<Movement>().setMoveSpeed(17f);
     yield return new WaitForSeconds(10f);
     c.g = y;
     rend.material.color = c;
     gameObject.GetComponent<Movement>().setMoveSpeed(x);
     

   }
}
