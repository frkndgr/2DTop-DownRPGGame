using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    private Rigidbody2D rb;
    public float chaseRadius;
    public float attackRadius;
    private Animator anim;

    public Transform homePos;

    private Transform target;
    


    public int skeletonDamage = 20;

    

    
    void Start()
    {
        currentState = EnemyState.idle;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    

    void FixedUpdate() 
    {
        CheckDistance();
        /*if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) > minRange)
        {
            
            fallowPlayer();
        }
        else if(Vector3.Distance(target.position, transform.position) > maxRange)
        {
            GoHome();
        }*/
    }

    void CheckDistance()
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

    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }

    /*public void fallowPlayer()
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

        if (Vector3.Distance(transform.position, homePos.position) == 0 )
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

    private void OnTriggerEnter2D(Collider2D other) 
    {

        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().TakeDamage(skeletonDamage);
        }

        
        
    }*/

    

    
}
