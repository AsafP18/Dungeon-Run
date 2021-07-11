using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Script : MonoBehaviour
{
    public GameObject thoughts;
    public GameObject instructions;
    string[] instructionsS;
    string[] thoughtsS;
    int Cinstructions;
    int Cthoughts;
    public int SpaceCounter;
    public bool sword;
    void Start()
    {
        gameObject.GetComponent<PlayerMovement>().speed = 0;
        sword = false;
        SpaceCounter = 0;
        Cinstructions = 0;
        Cthoughts = 0;
        thoughtsS = new string[] { " ...", "I had this crazy nightmare last night", "Dad?","That's Strange","He didnt come home last night", "I should probably go search for him in the dungeon", "I cant leave without my sword" };
        instructionsS = new string[] { "Press space to continue", "Use the arrow keys to move and E to pick up objects", "The Sword is your first weapon use it in the dungeon to attack with the 'Z' key " };
        thoughts.gameObject.SetActive(false);
        instructions.gameObject.GetComponentInChildren<Text>().text = instructionsS[Cinstructions];
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
    void Openinstructions()
    {
        instructions.gameObject.GetComponentInChildren<Text>().text = instructionsS[Cinstructions];
        instructions.gameObject.SetActive(true);
    }
    void Closethoughts()
    {
        thoughts.gameObject.SetActive(false);
        Cthoughts++;
    }
    void Closeinstructions()
    {
        instructions.gameObject.SetActive(false);
        Cinstructions++;
    }
     public void text(int counter)
    {
        if (counter == 0)
        {
            Closeinstructions();
            Openthoughts();
            SpaceCounter++;
        }
        else if(counter <= 5)
        {
            Closethoughts();
            Openthoughts();
            SpaceCounter++;
        }
        else if (counter == 6)
        {
            Closethoughts();
            Openinstructions();
            
            SpaceCounter++;
        }
        else if (counter == 7)
        {
            Closeinstructions();
            SpaceCounter++;
            gameObject.GetComponent<PlayerMovement>().speed = 8f;
        }
        else if (counter == 8)
        {
          
            
        }
        else if (counter == 9&&!sword)
        {
            Openthoughts();
        }
        else if (counter == 9&&sword)
        {
            Closethoughts();
            Openinstructions();
        }


    }
}
