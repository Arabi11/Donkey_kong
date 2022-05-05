using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunning : IPlayerState
{
   public void Enter(Player player){
         
   }

   public IPlayerState Tick(Player player)
   {
       
           if ( !PauseMenu.isPaused && Input.GetButtonDown("Horizontal"))
                {
                    Debug.Log("00000000");

                    player.direction.x = Input.GetAxis("Horizontal") * player.moveSpeed;
                    return player.playerIdle;
                    
                }

                if (Input.GetButtonDown("Jump")&& player.grounded)
                {
                    
                   return player.playerJumping;

                }
                else
                {
                    player.direction.x = Input.GetAxis("Horizontal") * player.moveSpeed;
                    player.direction += Physics2D.gravity * Time.deltaTime * 3;
                if (player.grounded)
                {
                    player.direction.y = Mathf.Max(player.direction.y, -1f);
                    return player.playerIdle;
                }

                }
       
       return player.playerIdle;
                
         
   }

}
