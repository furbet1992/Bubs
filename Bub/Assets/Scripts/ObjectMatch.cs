using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectMatch : MonoBehaviour
{

   public int FinalScore; 
   public int CurrentScore; 

    void Start()
    {
        //"Collect x amount of numbers to pass
        CurrentScore = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(CurrentScore);

        if (FinalScore == CurrentScore)
        {
            Debug.Log("Play Success Music, Play Star Particle Effect. Well Done"); 
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Apple")
        {
            Destroy(collision.gameObject);
            CurrentScore ++; 
        }
    }
}
