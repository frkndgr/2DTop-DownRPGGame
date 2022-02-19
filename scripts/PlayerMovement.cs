using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    stagger,
    idle,

}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    [SerializeField]
    private float moveSpeed =0f;
    public int warriorHealth = 100;
    public int warriorCurrentHealth = 100;

    public HealthManager healthManager;



    
    private Rigidbody2D rb;
    private Animator anim;

    private Vector2 moveDirection;
    private Vector2 lastMoveDirection;

    [SerializeField]
    private int attackDamage = 40;
    [SerializeField]
    private float attackRate = 2f;
    float nextAttackTime = 0f;
    


    private void Start() 
    {
        warriorCurrentHealth = warriorHealth;
        healthManager.SetMaxHealth(warriorHealth);
        currentState = PlayerState.walk;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();    
    }
    void Update()
    {
        
        ProcessInputs();
        Animate();

        
        
        if (Time.time >= nextAttackTime)
        {
           if (Input.GetKeyDown(KeyCode.Space))
            {
            
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            
            } 
        }
        

        
        

    
        

    }


    private void FixedUpdate() 
    {
        
        Move();
        
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

    

    public void TakeDamage(int skeletonDamage )
    {
        warriorCurrentHealth -= skeletonDamage;
        healthManager.SetHealth(warriorCurrentHealth);

        anim.SetTrigger("hurt");

        if (warriorCurrentHealth <= 0)
        {
            StartCoroutine(DieCo());
            
        }

    }

    IEnumerator DieCo()
    {
        moveSpeed = 0f;
        GetComponent<Collider2D>().enabled = false;
        anim.SetBool("dead", true);
        yield return new WaitForSeconds(1f);

        
        
    }

    
   

}
