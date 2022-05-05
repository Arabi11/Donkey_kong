using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle :  IPlayerState
{
   

    public IPlayerState Tick(Player player){
        
            player.direction += Physics2D.gravity * Time.deltaTime * 3;
                if (!PauseMenu.isPaused &&player.grounded && Input.GetButtonDown("Jump"))
                {
                    
                    return player.playerJumping;

                }
                else
                {
                    return player.playerRunning;

                }
   }
        
       
   }
    

    



