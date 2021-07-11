using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Level3Script : MonoBehaviour
{
    public GameObject thoughts;
    int Cthoughts;
    int SpaceCounter;
    string[] thoughtsS;
    public bool end;
    void Start()
    {
        Cthoughts = 0;
        SpaceCounter = 0;
        thoughtsS = new string[] { "EIIIIYAAAAA","NO NO NO","DAD!!!!!!" };
        thoughts.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(end)
        {
            gameObject.GetComponent<PlayerMovement>().speed = 0;
            end = false;
            Openthoughts();
        }
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            text(SpaceCounter);
        }
    }
    void Openthoughts()
    {
        thoughts.gameObject.GetComponentInChildren<Text>().text = thoughtsS[Cthoughts];
        thoughts.gameObject.SetActive(true);
    }
    void Closethoughts()
    {
        thoughts.gameObject.SetActive(false);
        Cthoughts++;
    }
    public void text(int counter)
    {
        if (counter < 2)
        {
          
            Closethoughts();
            Openthoughts();
            SpaceCounter++;
        }
        else
        {
            SceneManager.LoadScene(sceneName: "OpeningScene");
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "End")
        {
            end = true;
        }
    }
}
