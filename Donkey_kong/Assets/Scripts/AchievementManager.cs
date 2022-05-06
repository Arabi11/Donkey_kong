using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour, IAchievement
{
     [SerializeField] private Text achivementText;
    public void unlockAchievement(string ID){
   if(PlayerPrefs.GetInt(ID) == 1){
       return;
    }
    else{
        PlayerPrefs.SetInt(ID,1);
        ScoreManager.instance.setAchievementText(ID);
        Debug.Log("achivement-"+ID);
        }
    }

    
}
