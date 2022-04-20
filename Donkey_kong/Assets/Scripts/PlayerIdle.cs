using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle :  IPlayerState
{
   public void Enter(Player player){

   }

    public IPlayerState Tick(Player player){
        
         //player.addToDirection(Physics2D.gravity * Time.deltaTime * 3);
                if (player.getGrounded() && Input.GetButtonDown("Jump"))
                {
                    player.setDirection(Vector2.up * player.getJump());
                    
                    return new PlayerJumping();

                }
                else
                {
                   return new PlayerRunning();
                }
                
       
        
       
   }
    /**
    public void Exit(Player player){
         Destroy(this);
   }
**/

    
}


