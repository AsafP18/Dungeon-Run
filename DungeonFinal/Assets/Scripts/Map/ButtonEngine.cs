using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEngine : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(sceneName: "DungeonFloor");
    }    
    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }
  public void Quitting()
    {
        Application.Quit();
    }
}
