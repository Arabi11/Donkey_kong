using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerUps : MonoBehaviour
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
        if(col.gameObject.CompareTag("Steroids")){
            StartCoroutine("SpeedMan");
            Destroy(col.gameObject);
        }

        if(col.gameObject.CompareTag("HGH")){
            StartCoroutine("GiantMan");
            Destroy(col.gameObject);
        }
    }
   
  
   
   IEnumerator GetInvulnerable(){
       //Physics2D.IgnoreLayerCollision(7,8,true);
       c.a = 0.5f;
       rend.material.color = c;
       Physics2D.IgnoreLayerCollision(7,8,true);
       yield return new WaitForSeconds(5f);
       c.a =1f;
       rend.material.color =c;
       Physics2D.IgnoreLayerCollision(7,8,false);
       
       
      // FindObjectOfType.
       

   }

   IEnumerator SpeedMan(){

       float y = c.g ;
       c.g =5f;
       rend.material.color = c;
       float x = gameObject.GetComponent<Player>().moveSpeed;
        gameObject.GetComponent<Player>().setMoveSpeed(17f);
        gameObject.GetComponent<Player>().gameObject.transform.localScale = new Vector3 (5,5, 5);
     yield return new WaitForSeconds(10f);
     c.g = y;
     rend.material.color = c;
     gameObject.GetComponent<Player>().setMoveSpeed(x);
    

   }

   IEnumerator GiantMan(){

       float y = c.b ;
       c.b =5f;
       rend.material.color = c;
       
        gameObject.GetComponent<Player>().setGiant(true);
        gameObject.GetComponent<Player>().gameObject.transform.localScale = new Vector3 (5,5, 5);
        yield return new WaitForSeconds(10f);
        c.b = y;
        rend.material.color = c;
        
         gameObject.GetComponent<Player>().gameObject.transform.localScale = new Vector3 (1,1, 1);
        gameObject.GetComponent<Player>().setGiant(false);

   }
}
