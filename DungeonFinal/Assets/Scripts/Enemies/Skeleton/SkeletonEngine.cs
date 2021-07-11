using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEngine : MonoBehaviour
{
    public GameObject sword;
    public Transform FirePoint;
    float stopmoving=0;
    float startmoving=3;
    float fireRate = 6;
    float nextFire = 0;
    Animator anm;
    // Start is called before the first frame update
    void Start()
    {
        anm = GetComponent<Animator>();
       gameObject.GetComponent<EnemyMovement>().hp = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if ( !gameObject.GetComponent<EnemyMovement>().IsAttack&& Time.time > nextFire&& gameObject.GetComponent<EnemyMovement>().PlayerDistance(gameObject.GetComponent<EnemyMovement>().hero) < 5.5)
        {
            anm.SetTrigger("Throw");
            gameObject.GetComponent<EnemyMovement>().IsAttack = true;
            gameObject.GetComponent<EnemyMovement>().speed = 0;
            Instantiate(sword, FirePoint.position, sword.transform.rotation);
            nextFire = Time.time + fireRate;
            stopmoving = Time.time + startmoving;
            anm.SetTrigger("Idle");
        }
        if (gameObject.GetComponent<EnemyMovement>().IsAttack && Time.time > stopmoving)
        {
            gameObject.GetComponent<EnemyMovement>().IsAttack = false;
            gameObject.GetComponent<EnemyMovement>().speed = 0.9f;
            anm.SetTrigger("Walk");
        }

    }
}
