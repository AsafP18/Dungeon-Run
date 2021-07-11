using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEngine : MonoBehaviour
{
    Animator anm;
    string pos;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        anm = GetComponent<Animator>();
        gameObject.GetComponent<EnemyMovement>().hp = 1;
        player = GameObject.Find("Ellie").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        pos =gameObject.GetComponent<EnemyMovement>().PlayerRelativePosition(player);
        
        if (pos == "Right")
        {
                anm.SetBool("isSide", true);
                anm.SetBool("isFront", false);
                anm.SetBool("isBack", false);
           
        }
        else if (pos == "Left")
        {
          
                anm.SetBool("isSide", true);
                anm.SetBool("isFront", false);
                anm.SetBool("isBack", false);
           
        }
        else if (pos == "Up")
        {
           
                anm.SetBool("isSide", false);
                anm.SetBool("isFront", false);
                anm.SetBool("isBack", true);
           
        }
        else if (pos == "Down")
        {
           
                anm.SetBool("isSide", false);
                anm.SetBool("isFront", true);
                anm.SetBool("isBack", false);
          
        }
    }
}
