using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    [SerializeField] private Text scoreText;

    [SerializeField] private  Text highscoreText;

    int score = 0;
    int highscore = 0;


    // Start is called before the first frame update
    void Start()
    {   
        PlayerPrefs.DeleteAll();
        highscore =PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString()+"POINTS";
        highscoreText.text = "HIGHSCORE:"+highscore.ToString();
    }

    public void AddPoint(){
        score += 10;
        scoreText.text = score.ToString()+"POINTS";
        if(highscore< score){
        PlayerPrefs.SetInt("highscore", score);
        }
    }

     public void AddJumpPoint(){
        score += 50;
        scoreText.text = score.ToString()+"POINTS";
        if(highscore< score){
        PlayerPrefs.SetInt("highscore", score);
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
