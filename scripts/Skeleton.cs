using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    private Rigidbody2D rb;
    public float chaseRadius;
    public float attackRadius;
    public Animator anim;

    public Transform homePos;

    public Transform target;
    


    public int skeletonDamage = 20;

    public PlayerMovement playerMovement;

    

    

    
    void Start()
    {
        maxHealth = 100;
        currenthealth = 100;
        currentState = EnemyState.idle;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        
    }

    

    void FixedUpdate() 
    {
        //CheckDistance();
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius && playerMovement.warriorCurrentHealth >= 0)
        {
            
            fallowPlayer();
        }
        else if(Vector3.Distance(target.position, transform.position) > chaseRadius )
        {
            GoHome();
        }

        if (playerMovement.warriorCurrentHealth <= 0)
        {
            speed = 0.4f;
            attackRadius = 4f;
            anim.SetBool("attack", false);
            anim.SetBool("isMoving", true);
            GoHome();
        }
    }

    /*void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius )
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger )
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                
                changeAnim(temp - transform.position);
                rb.MovePosition(temp);
                ChangeState(EnemyState.walk);
                anim.SetBool("isMoving", true);
            
            }
        }else if(Vector3.Distance(target.position, transform.position) > chaseRadius )
        {
            
            anim.SetBool("isMoving", false);
        }
    }

    private void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }
    private void changeAnim(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x >0)
            {
                SetAnimFloat(Vector2.right);
            }else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }

        }else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }
    */

    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
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
        
        if (Vector3.Distance(target.position, transform.position) <= attackRadius)
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

        if (Vector3.Distance(transform.position, homePos.position) == 0 )
        {
            anim.SetBool("isMoving", false);
        }
    }
    
    
    public void TakeDamage(int damage)
    {
        currenthealth -= damage;

        anim.SetTrigger("hurt");

        if (currenthealth <= 0)
        {
            StartCoroutine(DieCo());
        }

    }

    IEnumerator DieCo()
    {
        speed = 0f;
        attackRadius = 4f;
        
        anim.SetBool("dead", true);
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(5f);

        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {

        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().TakeDamage(skeletonDamage);
        }

        
        
    }

    

    
}
