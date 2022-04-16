using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int level;
   
    

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        NewGame();
    }

    private void NewGame()
    {
        
        
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
       
            LoadLevel();
        
    }

}