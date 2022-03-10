using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorHit : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("breakable"))
        {
            other.GetComponent<BreakableRock>().Smash();  
        }

        if (other.CompareTag("enemy"))
        {
            other.GetComponent<Skeleton>().TakeDamage(20);
        }

        if(other.CompareTag("tomb"))
        {
            other.GetComponent<tombBreak>().breakOne();
        }

        if (other.CompareTag("boss"))
        {
            other.GetComponent<BossController>().TakeDamage(35);
        }
        
        if (other.CompareTag("dark"))
        {
            other.GetComponent<darkCharacter>().TakeDamage(35);
        }
        

        
        
    }
}
