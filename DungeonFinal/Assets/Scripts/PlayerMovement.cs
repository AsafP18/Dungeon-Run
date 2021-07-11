using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
   public float speed;
    float scale;
    Animator anm;
    bool side, up, down;
    float AttckSpeed = 0.5f;
    float nextFire = 0;
    public AudioSource source;
    public AudioClip clip;
    public bool isDead;//Knows when dead to stop attack.. updated in HealthEngine
    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
        side = true;up = false;down = false;
        scale = transform.localScale.x;
        anm = GetComponent<Animator>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            side = true; up = false; down = false;
            anm.SetBool("SideWalk", true);
            anm.SetBool("DownWalk", false);
            anm.SetBool("UpWalk", false);
            transform.Translate(speed*Time.deltaTime, 0, 0);
            transform.localScale = new Vector2(scale, transform.localScale.y);
        }
       else if (Input.GetKey(KeyCode.LeftArrow) == true)
        {

            side = true; up = false; down = false;
            anm.SetBool("SideWalk", true);
            anm.SetBool("DownWalk", false);
            anm.SetBool("UpWalk", false);
            transform.Translate(-speed*Time.deltaTime, 0, 0);
            transform.localScale = new Vector2(-scale, transform.localScale.y);
        }
        else
            anm.SetBool("SideWalk", false);
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            side = false; up = true; down = false;
            anm.SetBool("SideWalk", false);
            anm.SetBool("DownWalk", false);
            anm.SetBool("UpWalk", true);
            transform.Translate(0, speed*Time.deltaTime, 0);
        }
        else
            anm.SetBool("UpWalk", false);
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            side = false; up = false; down = true;
            anm.SetBool("SideWalk", false);
            anm.SetBool("DownWalk", true);
            anm.SetBool("UpWalk", false);
            transform.Translate(0, -speed*Time.deltaTime, 0);
        }
        else
            anm.SetBool("DownWalk", false);
        if (Input.GetKeyDown(KeyCode.Z) == true&&!isDead)
        {
            if (Time.time > nextFire)
            {
                if (side)
                    anm.SetTrigger("SideAttack");
                if (up)
                    anm.SetTrigger("UpAttack");
                if (down)
                    anm.SetTrigger("DownAttack");
                nextFire = Time.time + AttckSpeed;
                source.PlayOneShot(clip);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
          if (Input.GetKey(KeyCode.E) == true)
           {
                anm.SetTrigger("Pickup");
                gameObject.GetComponent<Level1Script>().sword = true;
                gameObject.GetComponent<Level1Script>().SpaceCounter++;
                Destroy(collision);
                gameObject.GetComponent<Level1Script>().text(9);
          }
        }
        if (collision.gameObject.tag == "Exit")
        {
            if (gameObject.GetComponent<Level1Script>().sword)
            {
                SceneManager.LoadScene(sceneName: "Town");
            }
            else
            {
                gameObject.GetComponent<Level1Script>().SpaceCounter++;
                gameObject.GetComponent<Level1Script>().text(gameObject.GetComponent<Level1Script>().SpaceCounter);
            }
        }
        if (collision.gameObject.tag == "Exit2")
        {
                SceneManager.LoadScene(sceneName: "DungeonFloor");          
        }
        if(collision.gameObject.tag=="SpeedPotion"&&Input.GetKey(KeyCode.E))
        {
            Destroy(collision.gameObject);
            speed += 2f;
        }
    }
}
