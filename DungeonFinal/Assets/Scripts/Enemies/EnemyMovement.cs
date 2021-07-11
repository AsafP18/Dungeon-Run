using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform hero;
    public float speed;
    public Animator anm;
    float scale;
    public string pos;
    public bool IsAttack;
    public int hp;
    // Start is called before the first frame update
    void Start()
    {

        IsAttack = false;
        speed = 0;
        anm = GetComponent<Animator>();
        scale = transform.localScale.x;
        hero = GameObject.Find("Ellie").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = PlayerRelativePosition(hero);
        if (speed == 0 && PlayerDistance(hero) < 5.5&&!IsAttack)
            speed = 0.9f;

        if (pos=="Right")
        {
            transform.position = Vector2.MoveTowards(transform.localPosition, hero.position, speed * Time.deltaTime);
            transform.localScale = new Vector2(scale, scale);
        }
        else if(pos=="Left")
        {
            transform.position = Vector2.MoveTowards(transform.localPosition, hero.position, speed * Time.deltaTime);
            transform.localScale = new Vector2(-scale,scale);
        }
        else if(pos=="Up")
        {
            transform.position = Vector2.MoveTowards(transform.localPosition, hero.position, speed * Time.deltaTime);
            transform.localScale = new Vector2(scale, scale);
        }
       else if(pos=="Down")
        {
            transform.position = Vector2.MoveTowards(transform.localPosition, hero.position, speed * Time.deltaTime);
            transform.localScale = new Vector2(scale, scale);
        }
    }
    public string PlayerRelativePosition(Transform player)//Returns the position of the player relative to the enemy
    {
        if (player.position.x > (transform.position.x) - 1.5f && player.position.x < transform.position.x + 1.5f && player.position.y >= transform.position.y)
            return "Up";
         if (player.position.x > (transform.position.x) - 1.5f && player.position.x < transform.position.x + 1.5f && player.position.y <= transform.position.y)
            return "Down";
        else if (player.position.x > transform.position.x)
            return "Right";
        else
            return "Left";
    }
    public float PlayerDistance(Transform player)//Returns the distance of the player from the enemy
    {
        float x =Mathf.Pow( (player.position.x - transform.position.x),2);
        float y =Mathf.Pow( (player.position.y - transform.position.y),2);
        float dis = Mathf.Sqrt(x + y);
        return dis;
    }
}
