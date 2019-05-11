using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool needPause;
    public GameObject Psemenu;
    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }  
    public void PauseMenu()
    {
       
        if (needPause)
        {   
            Time.timeScale = 0;
            Psemenu.SetActive(true);    
        }
        
    }
    public void Resume()
    {
        Time.timeScale = 1;
        Psemenu.SetActive(false);
    }

   
}
