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
        
    }
}
