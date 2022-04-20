using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : IPlayerState
{
   public void Enter(Player player){
       
   }

   public IPlayerState Tick(Player player){

       Debug.Log("sf");
                player.setDirectionx(Input.GetAxis("Horizontal") * player.getMoveSpeed());
                player.addToDirection(Physics2D.gravity * Time.deltaTime * 3);
                
                if (player.getGrounded())
                {
                    player.setDirectiony(Mathf.Max(player.getDirectiony(),1f));
                    //IDLE;
                    return new PlayerIdle();
                }

            return null;
   }
/**
   public void Exit(Player player){
         Destroy(this);
   }**/
}
