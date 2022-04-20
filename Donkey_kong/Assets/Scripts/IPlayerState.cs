using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState 
{
   public IPlayerState Tick();
   public void Enter();
   public void Exit();
}
