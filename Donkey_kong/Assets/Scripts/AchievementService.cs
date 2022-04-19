using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementService : MonoBehaviour
{
    private IAchievement achievementImplementation;
    
    
    void Awake()
    {
        achievementImplementation = GetComponent<IAchievement>();
    }

    public void unlockAchievement(string ID){
        achievementImplementation.unlockAchievement(ID);
    }
}
