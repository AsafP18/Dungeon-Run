using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEngine : MonoBehaviour
{
    GameObject[] Spikes;
    // Start is called before the first frame update
    void Start()
    {
        Spikes = new GameObject[8];
        for(int i=0;i<8;i++)
        {
            Spikes[i] = GameObject.Find("Spike" + (i+1));
         
         
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DownSpike(int num)//Turns off spike and num is the first of two spikes to take down
    {
        for(int i=num;i<=num+1;i++)
        {
            Spikes[i].GetComponent<Animator>().SetTrigger("SpikeDown");
            Spikes[i].GetComponent<Collider2D>().enabled = false;
        }
    }
}
