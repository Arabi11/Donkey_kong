using UnityEngine;

public class Player : MonoBehaviour
{
   private new Rigidbody2D rigidbody;

   private void Awake(){
      rigidbody = GetComponent<Rigidbody2D>();
   }
}
