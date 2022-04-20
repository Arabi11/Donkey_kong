using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : IPlayerState
{
   public void Enter(Player player){
       
   }

   public IPlayerState Tick(Player player){       
                player.direction = Vector2.up * player.jumpStrength;
                player.direction.x = Input.GetAxis("Horizontal") * player.moveSpeed;
                player.direction += Physics2D.gravity * Time.deltaTime * 3;
                if (player.grounded)
                {
                    player.direction.y = Mathf.Max(player.direction.y, -1f);

                     return player.playerIdle;
                }
                else{
                    return player.playerIdle;
                }
   }

}
