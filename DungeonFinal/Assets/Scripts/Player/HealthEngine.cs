using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthEngine : MonoBehaviour
{
    public int health;
    public int NumofHearts;
    public Image[] heartimages;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    public PlayerMovement movement;
    float HitRate = 0.5f;
    float NextHit = 0;
    //Ellie Hit sound
    public AudioSource source;
    public AudioClip Hitclip;
    public AudioClip SlurpClip;
    GameObject gameoverpanel;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        NumofHearts = 3;
        UpdateHealth(health, NumofHearts);
        gameoverpanel = GameObject.Find("GameOverPanel");
        gameoverpanel.SetActive(false);
        movement = GameObject.Find("Ellie").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateHealth(int health,int heartsnum)//health decreases per hit, heart and health increase every potion
    {
        if (health > heartsnum)
            health = heartsnum;
        for (int i = 0; i < heartimages.Length; i++)
        {
            if (i < health)
                heartimages[i].sprite = FullHeart;
            else
                heartimages[i].sprite = EmptyHeart;
            if (i < heartsnum)
                heartimages[i].enabled = true;
            else
                heartimages[i].enabled = false;
        }
    }
    public void TakeHealthPotion()
    {
        source.PlayOneShot(SlurpClip);
        if (health == NumofHearts)
            UpdateHealth(++health, ++NumofHearts);
        else
            UpdateHealth(++health, NumofHearts);
    }
    public void ReduceHealth()
    {
        if (Time.time > NextHit)
        {
            UpdateHealth(--health, NumofHearts);
            if(health>=0)
              source.PlayOneShot(Hitclip);
            if (health == 0)
            {
                gameoverpanel.SetActive(true);
                movement.speed = 0;
                movement.isDead = true;
            }
            NextHit = Time.time + HitRate;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy"||collision.gameObject.tag=="Spike"||collision.gameObject.tag=="Projectile")
            ReduceHealth();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HealthPotion" && Input.GetKey(KeyCode.E))
        {
            TakeHealthPotion();
            Destroy(collision.gameObject);
        }
    }
}
