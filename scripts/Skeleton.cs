using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    
    
    public int maxHealth = 100;
    int currentHealth;

    private Animator anim;

    public Transform homePos;

    private Transform target;
    [SerializeField]
    private float speed = 0f;
    [SerializeField]
    private float maxRange = 0f;
    [SerializeField]
    private float minRange = 0f;
    




    void Start()
    {
        currentHealth = maxHealth;

        anim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update() 
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            
            fallowPlayer();
        }
        else if(Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            GoHome();
        }
    }

    public void fallowPlayer()
    {
        speed = 0.5f;
        anim.SetBool("attack", false);
        anim.SetBool("isMoving", true);
        anim.SetFloat("moveX", (target.position.x - transform.position.x));
        anim.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        
        if (Vector3.Distance(target.position, transform.position) <= minRange)
        {
            anim.SetBool("isMoving", false);
            speed = 0f;
            anim.SetBool("attack", true);
            
            
        }
    }

    public void GoHome()
    {
        anim.SetFloat("moveX", (homePos.position.x - transform.position.x));
        anim.SetFloat("moveY", (homePos.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, homePos.position) == 0)
        {
            anim.SetBool("isMoving", false);
        }
    }
    
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        anim.SetTrigger("hurt");

        if (currentHealth <= 0)
        {
            StartCoroutine(DieCo());
        }

    }

    IEnumerator DieCo()
    {
        speed = 0f;
        maxRange = 0f;
        anim.SetBool("dead", true);
        yield return new WaitForSeconds(5f);

        GetComponent<Collider2D>().enabled = false;
        this.gameObject.SetActive(false);
    }

    
}
