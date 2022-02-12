using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableRock : MonoBehaviour
{
    private Animator anim;

    public int healt = 100;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    public void Smash()
    {
        anim.SetBool("smash", true);
        healt -= 25;
        StartCoroutine(breakCo());
    }

    IEnumerator breakCo()
    {
        yield return new WaitForSeconds(0.22f);
        anim.SetBool("smash", false);
        
        if (healt<=0)
        {
            anim.SetBool("break", true);
            yield return new WaitForSeconds(3f);
            this.gameObject.SetActive(false);
        }
        
    }
}
