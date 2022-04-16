using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    [SerializeField] private Text scoreText;

    [SerializeField] private  Text highscoreText;

    int score =0;
    int highscore = 0;


    // Start is called before the first frame update
    void Start()
    {   
        PlayerPrefs.DeleteKey("score");
       
        highscore =PlayerPrefs.GetInt("highscore", 0);

        score = PlayerPrefs.GetInt("score", 0);
        scoreText.text = " POINTS: " + score.ToString();

        highscoreText.text = "HIGHSCORE:"+highscore.ToString();
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

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake(){
        instance = this;
    }
}
