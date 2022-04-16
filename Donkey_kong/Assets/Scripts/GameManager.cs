using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int level;
    private int lives=3;
   
    

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(1);
    }

    private void NewGame()
    {
        
       PlayerPrefs.DeleteKey("score");
        LoadLevel();
    }

    private void LoadLevel()
    {
        

        Camera camera = Camera.main;

        
        if (camera != null) {
            camera.cullingMask = 0;
        }

        Invoke(nameof(LoadScene), 1f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(2);
    }


    public void LevelFailed()
    {
        lives--;

        if (lives <= 0) {
            NewGame();
        } else {
            LoadLevel();
        }
        
    }

    public void AddLives()
    {
       
            lives ++;
        
    }

}