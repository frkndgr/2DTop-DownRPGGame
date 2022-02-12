using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    /*private float attackTime = 0.25f;
    private float attackCounter = 0.25f;
    private bool isAttacking; 
    */
    public Rigidbody2D rb;
    public Animator anim;

    private Vector2 moveDirection;
    private Vector2 lastMoveDirection;
    



    void Update()
    {
        
        ProcessInputs();
        Animate();
        Move();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Attack();
            
        }
        

    
        

    }

    private void FixedUpdate() 
    {
        

        
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        

        if ((moveX == 0 && moveY == 0) && moveDirection.x != 0 || moveDirection.y != 0)
        {
            lastMoveDirection = moveDirection;
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        
        
        /*if (isAttacking)
        {
            rb.velocity = Vector2.zero;
            attackCounter -= Time.deltaTime;
            if (attackCounter <=0)
            {
                anim.SetBool("AnimAttack", false);
                isAttacking = false;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attackCounter = attackTime;
            anim.SetBool("AnimAttack", true);
            isAttacking = true;
        }
        */
        
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void Animate()
    {
        anim.SetFloat("AnimMoveX", moveDirection.x);
        anim.SetFloat("AnimMoveY", moveDirection.y);
        anim.SetFloat("AnimMoveMagnitude", moveDirection.magnitude);
        anim.SetFloat("AnimLastMoveX", lastMoveDirection.x);
        anim.SetFloat("AnimLastMoveY", lastMoveDirection.y);
        
    }

    void Attack()
    {
        
        anim.SetTrigger("AnimAttack");
        
    }

}
