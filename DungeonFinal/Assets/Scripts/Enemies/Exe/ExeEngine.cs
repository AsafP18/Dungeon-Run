using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExeEngine : MonoBehaviour
{
    public GameObject ghost;
    public GameObject bat;
    public Transform FirePoint;
    float stopmoving = 0;
    float startmoving = 3;
    float fireRate = 6;
    float nextFire = 0;
    float SummonRate = 10;
    float nextSummon = 0;
    Animator anm;
    void Start()
    {
        anm = GetComponent<Animator>();
        gameObject.GetComponent<EnemyMovement>().hp = 10;

    }

    // Update is called once per frame
    void Update()
    {

        if (!gameObject.GetComponent<EnemyMovement>().IsAttack && Time.time > nextFire && gameObject.GetComponent<EnemyMovement>().PlayerDistance(gameObject.GetComponent<EnemyMovement>().hero) < 5.5f)
        {
            anm.SetTrigger("Skill");
            gameObject.GetComponent<EnemyMovement>().IsAttack = true;
            gameObject.GetComponent<EnemyMovement>().speed = 0;
            Instantiate(ghost, FirePoint.position, ghost.transform.rotation);
            Instantiate(ghost, FirePoint.position, Quaternion.AngleAxis(90, Vector3.forward));
            Instantiate(ghost, FirePoint.position, Quaternion.AngleAxis(180, Vector3.forward));
            Instantiate(ghost, FirePoint.position, Quaternion.AngleAxis(270, Vector3.forward));
            nextFire = Time.time + fireRate;
            stopmoving = Time.time + startmoving;
          
        }
        if (!gameObject.GetComponent<EnemyMovement>().IsAttack && Time.time > nextSummon && gameObject.GetComponent<EnemyMovement>().PlayerDistance(gameObject.GetComponent<EnemyMovement>().hero) < 5.5f)
        {
            anm.SetTrigger("Skill");
            gameObject.GetComponent<EnemyMovement>().IsAttack = true;
            gameObject.GetComponent<EnemyMovement>().speed = 0;
            Instantiate(bat, FirePoint.position, bat.transform.rotation);
            Instantiate(bat, FirePoint.position, bat.transform.rotation);     
            nextSummon = Time.time + SummonRate;
            stopmoving = Time.time + startmoving;

        }
        if (gameObject.GetComponent<EnemyMovement>().IsAttack && Time.time > stopmoving)
        {
            gameObject.GetComponent<EnemyMovement>().IsAttack = false;
            gameObject.GetComponent<EnemyMovement>().speed = 0.9f;
            
        }

    }
}
