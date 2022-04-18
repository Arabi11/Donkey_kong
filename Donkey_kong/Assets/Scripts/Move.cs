using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")){
            MoveCommand moveUp = new MoveCommand(transform, Vector2.up);
            moveUp.Execute();
        }

        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
           MoveCommand moveLeft = new MoveCommand(transform, Vector2.up);
           moveLeft.Execute();
        }

        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            MoveCommand moveRight = new MoveCommand(transform, Vector2.up);
           moveRight.Execute();
        }
    }
}
