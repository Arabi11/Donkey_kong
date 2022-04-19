using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour, IAchievement
{

    public void unlockAchievement(string ID){
   if(PlayerPrefs.GetInt(ID) == 1){
       return;
    }
    else{
        PlayerPrefs.SetInt(ID,1);
        Debug.Log("achivement-"+ID);
    }
    }
}
