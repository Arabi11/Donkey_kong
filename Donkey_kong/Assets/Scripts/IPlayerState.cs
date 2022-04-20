using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
   public IPlayerState Tick(Player player);
  

}
