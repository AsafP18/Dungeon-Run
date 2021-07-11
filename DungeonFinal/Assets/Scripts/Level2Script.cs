using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Script : MonoBehaviour
{
    public GameObject thoughts;
    int Cthoughts;
    int SpaceCounter;
    string[] thoughtsS;
    // Start is called before the first frame update
    void Start()
    {
     
        Cthoughts = 0;
        SpaceCounter = 0;
        thoughtsS = new string[] { "i'm feeling anxious", "After all Im the reason he went there alone after the fight we had last night", "if i'm not mistaken,the entrance is down here to the right" };
        thoughts.gameObject.GetComponentInChildren<Text>().text = thoughtsS[Cthoughts];
        gameObject.GetComponent<PlayerMovement>().speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (counter<2)
        {
            
            Closethoughts();
            Openthoughts();
            SpaceCounter++;
        }
        else
        {
            gameObject.GetComponent<PlayerMovement>().speed = 8f;
            Closethoughts();
        }
      

    }
}
