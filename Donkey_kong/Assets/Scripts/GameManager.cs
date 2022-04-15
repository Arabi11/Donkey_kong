using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int level;
    private int lives;
    private int score;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        NewGame();
    }

    private void NewGame()
    {
        lives = 3;
        score = 0;

        LoadLevel(1);
    }

    private void LoadLevel(int index)
    {
        level = index;

        Camera camera = Camera.main;

        
        if (camera != null) {
            camera.cullingMask = 0;
        }

        Invoke(nameof(LoadScene), 1f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(level);
    }

   public void AddPoint(){
       score += 10;
   }

    public void JumpPoint(){
       score += 50;
   }

    public void LevelFailed()
    {
        lives--;

        if (lives <= 0) {
            NewGame();
        } else {
            LoadLevel(level);
        }
    }

}