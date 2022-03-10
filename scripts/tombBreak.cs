using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tombBreak : MonoBehaviour
{
    
    Animator anim;
    public int tombHealth = 100;
    PlayerMovement playerMovement;

    public GameObject skull;
    

    


    void Start()
    {
        anim = GetComponent<Animator>();
        
        
    }

    
    void Update()
    {
        
    }

    public void breakOne()
    {
        tombHealth -= 25;
        breakMoreCo();
        
        
    }

    private void breakMoreCo()
    {
        if (tombHealth <=75)
        {
            anim.SetBool("break", true);
        }
        
        if (tombHealth <=0)
        {
            anim.SetBool("breakMore", true);
            skullOpen();
            GetComponent<Collider2D>().enabled = false;
            
            
        }
    }

    public void skullOpen()
    {
        skull.SetActive(true); 
        
    }
}
