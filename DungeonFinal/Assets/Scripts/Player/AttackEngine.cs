using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEngine : MonoBehaviour
{
    int numofEnemieskilled;//to know when to remove spikes;
    SpikeEngine spike;//Removes Spike
    float fireRate = 0.5f;
    float nextFire = 0;
    public AudioSource source;
    public AudioClip clip;
    // Start is called before the first frame update
    private void Start()
    {
        numofEnemieskilled = 0;
        spike = GameObject.Find("SpikeManager").GetComponent<SpikeEngine>();
    }
    // Start is called before the first frame update
    private void OnCollisionStay2D(Collision2D collision)
    {
         if (Time.time > nextFire)
        { 

           if (collision.gameObject.tag == "Enemy")
           {
            collision.gameObject.GetComponent<EnemyMovement>().hp--;
            if (collision.gameObject.GetComponent<EnemyMovement>().hp == 0)
            {
                    collision.gameObject.GetComponent<Animator>().SetTrigger("isDead");
                    collision.gameObject.GetComponent<Collider2D>().enabled = false;
                    collision.gameObject.GetComponent<EnemyMovement>().speed = 0;
                Destroy(collision.gameObject,0.9f);
                    source.PlayOneShot(clip);
                numofEnemieskilled++;
            }
            else
                collision.gameObject.GetComponent<EnemyMovement>().anm.SetTrigger("Hit");

           }
            if (numofEnemieskilled == 3)
                spike.DownSpike(0);
            else if (numofEnemieskilled == 7)
                spike.DownSpike(2);
            else if (numofEnemieskilled == 9)
                spike.DownSpike(4);
            else if (numofEnemieskilled == 12)
                spike.DownSpike(6);
            nextFire = Time.time + fireRate;
        }
    }
   
}
