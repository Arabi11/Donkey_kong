using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunning : IPlayerState
{
   public void Enter(Player player){
         
   }

   public IPlayerState Tick(Player player){
          if (Input.GetButtonDown("Horizontal"))
                {
                    Debug.Log("00000000");

                    player.setDirectionx(Input.GetAxis("Horizontal") * player.getMoveSpeed());
                    //IDLE
                    return new PlayerIdle();
                    
                }

                if (Input.GetButtonDown("Jump"))
                {
                    player.setDirection(Vector2.up * player.getJump());
                    
                  //JUMPING;
                  return new PlayerJumping();

                }
                else
                {
                    
                    player.setDirectionx(Input.GetAxis("Horizontal") * player.getMoveSpeed());
                   player.addToDirection(Physics2D.gravity * Time.deltaTime * 3);
                    
                if (player.getGrounded())
                {
                    player.setDirectiony(Mathf.Max(player.getDirectiony(),1f));
                    //IDLE
                   return new PlayerIdle();
                }

                }
         return null;
   }
/**
   public void Exit(Player player){
         Destroy(this);
   }**/
}
