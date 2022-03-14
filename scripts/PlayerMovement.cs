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
    //[SerializeField] private HealthManager health;
    public GameOverScreen gameOverScreen;


    
    private Rigidbody2D rb;
    private Animator anim;

    private Vector2 moveDirection;
    private Vector2 lastMoveDirection;
    private Vector2 initPos;

    
    //private int attackDamage = 40;
    [SerializeField]
    private float attackRate = 2f;
    float nextAttackTime = 0f;
    float nextSkillTime = 0f;
    //public SpriteRenderer MySpriteRenderer;
    


    private void Start() 
    {
        warriorCurrentHealth = warriorHealth;
        healthManager.SetMaxHealth(warriorHealth);
        currentState = PlayerState.walk;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //initPos = transform.position;  
        //health.Initialize(warriorHealth,warriorHealth);  
    }
    void Update()
    {
        
        ProcessInputs();
        Animate();

        if (warriorCurrentHealth > 0)
        {
            if (Time.time >= nextAttackTime)
        {
           if (Input.GetKeyDown(KeyCode.Space))
            {
                moveSpeed = 0f;
                StartCoroutine(Attack());
                nextAttackTime = Time.time + 1f / attackRate;
            
            }

             
        }

        if (Time.time >= nextSkillTime)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                GetComponent<Collider2D>().enabled = false;
                moveSpeed = 0f;
                StartCoroutine(Attack2());
                nextSkillTime = Time.time + 5f / attackRate;
            }
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

    private IEnumerator Attack()
    {
        
        anim.SetTrigger("AnimAttack");
        yield return new WaitForSeconds(0.3f);
        moveSpeed = 0.75f;
        
        
    }

    private IEnumerator Attack2()
    {
        
        anim.SetTrigger("AnimAttack2");
        yield return new WaitForSeconds(1f);
        GetComponent<Collider2D>().enabled = true;
        moveSpeed = 0.75f;
        
        
    }

    

    public void TakeDamage(int skeletonDamage )
    {
        warriorCurrentHealth -= skeletonDamage;
        healthManager.SetHealth(warriorCurrentHealth);
        //health.MyCurrentValue -= skeletonDamage;
        

        anim.SetTrigger("hurt");

        if (warriorCurrentHealth <= 0)
        {
            StartCoroutine(DieCo());
            
        }

    }

    IEnumerator DieCo()
    {
        gameOverScreen.Setup();
        StopCoroutine(Attack());
        StopCoroutine(Attack2());
        nextAttackTime = 0f;
        moveSpeed = 0f;
        GetComponent<Collider2D>().enabled = false;
        anim.SetBool("dead", true);
        yield return new WaitForSeconds(3f);
        //MySpriteRenderer.enabled = false;
        //StartCoroutine(RespawnCo());


        
        
    }

    /*public IEnumerator RespawnCo()
    {
        warriorHealth = 100;
        yield return new WaitForSeconds(1f);
        transform.position = initPos;
        MySpriteRenderer.enabled = true;
        moveSpeed = 0.75f;
        warriorCurrentHealth = warriorHealth;
        anim.SetTrigger("respawn");
        

    }*/

    
   

}
