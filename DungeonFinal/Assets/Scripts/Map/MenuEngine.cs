using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEngine : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject info;
    void Start()
    {
        info.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(sceneName: "Room");
    }
    public void doExitGame()
    {
        Application.Quit();
    }
    public void OpenInfo()
    {

        info.gameObject.SetActive(true);
    }
    public void CloseInfo()
    {
        info.gameObject.SetActive(false);
    }
}
