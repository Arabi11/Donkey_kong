using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
   Transform target;
    Vector2 translation;
    float moveStrength;

    Vector2 direction;

    public MoveCommand(Transform target, Vector2 translation){
        this.target =target;
        this.translation = translation;
        
    }

    public override void Execute(){
        target.Translate(translation);
    }
   
}