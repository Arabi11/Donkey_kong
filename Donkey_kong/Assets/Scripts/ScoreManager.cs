using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    [SerializeField] private Text scoreText;

    [SerializeField] private  Text highscoreText;

   [SerializeField] private  Text achievementText;

    int score =0;
    int highscore = 0;

    float missingTime = 0;


    // Start is called before the first frame update
    void Start()
    {   
         
        PlayerPrefs.DeleteKey("score");
       
        highscore =PlayerPrefs.GetInt("highscore", 0);

        score = PlayerPrefs.GetInt("score", 0);
        scoreText.text = " POINTS: " + score.ToString();

        highscoreText.text = "HIGHSCORE:"+highscore.ToString();
    }
    public void Update(){
         if(missingTime > 0){
            missingTime -= Time.deltaTime;
        }
        else{
            achievementText.text = "";
        }
    }
    

    
    public void setAchievementText(string input){
        achievementText.text = "Achivement: "+input;
        missingTime = 10;
        
    }
   
   
    
    

    
     public void AddPoint(int x){
        
        score += x;
        PlayerPrefs.SetInt("score", score);
        scoreText.text = " POINTS: " + score.ToString();
        if(highscore< score){
            PlayerPrefs.SetInt("highscore", score);
            highscoreText.text = "HIGHSCORE:"+score.ToString();
        }
    }

   
   

    void Awake(){
        instance = this;
    }
}
