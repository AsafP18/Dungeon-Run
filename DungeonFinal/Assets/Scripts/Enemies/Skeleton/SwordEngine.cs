using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEngine : MonoBehaviour
{
    public string pos;
    Transform hero;
    float speed;
    float counter;
    // Start is called before the first frame update
    void Start()
    {
        hero = GameObject.Find("Ellie").GetComponent<Transform>();
        speed = 1.5f;
        counter = Time.time+3;
    }

    // Update is called once per frame
    void Update()
    { 
     if(Time.time< counter)
       {
            pos = PlayerRelativePosition(hero);
            if (pos == "Right")
        {
            transform.position = Vector2.MoveTowards(transform.localPosition, hero.position, speed * Time.deltaTime);
           
        }
        else if (pos == "Left")
        {
            transform.position = Vector2.MoveTowards(transform.localPosition, hero.position, speed * Time.deltaTime);
            
        
        }
        else if (pos == "Up")
        {
            transform.position = Vector2.MoveTowards(transform.localPosition, hero.position, speed * Time.deltaTime);

         
        }
        else if (pos == "Down")
        {
            transform.position = Vector2.MoveTowards(transform.localPosition, hero.position, speed * Time.deltaTime);

           
        }
       }
     else
        {
            if (pos == "Right")
            {
                transform.Translate(0.05f, 0, 0); 

            }
            else if (pos == "Left")
            {
                transform.Translate(-0.05f, 0, 0);


            }
            else if (pos == "Up")
            {
                transform.Translate(0, 0.05f, 0);


            }
            else if (pos == "Down")
            {
                transform.Translate(0, -0.05f, 0);


            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag!="Enemy")
        Destroy(gameObject);
    }
    public string PlayerRelativePosition(Transform player)//Returns the position of the player relative to the enemy
    {
        if (player.position.x > (transform.position.x) - 2.5f && player.position.x < transform.position.x + 2.5f && player.position.y >= transform.position.y)
            return "Up";
        if (player.position.x > (transform.position.x) - 2.5f && player.position.x < transform.position.x + 2.5f && player.position.y <= transform.position.y)
            return "Down";
        else if (player.position.x > transform.position.x)
            return "Right";
        else
            return "Left";
    }
}
