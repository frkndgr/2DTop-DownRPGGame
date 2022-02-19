using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger,
}
public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public int maxHealth;
    public int currenthealth;
    public string enemyName;
    public int baseAttack;
    public float speed;

    private void Awake() 
    {
        currenthealth = maxHealth;
    }
    
    private void TakeDamage(int damage)
    {
        currenthealth -= damage;
        if (currenthealth <=0)
        {
            this.gameObject.SetActive(false);
        }
    }
    public void Knock(Rigidbody2D rb, float knockTime, int damage)
    {
        StartCoroutine(KnockCo(rb, knockTime));
        TakeDamage(damage);
        
    }

    private IEnumerator KnockCo(Rigidbody2D rb, float knockTime)
    {
        if (rb != null)
        {
            yield return new WaitForSeconds(knockTime);
            rb.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            rb.velocity = Vector2.zero;
            
        }
    }



    
}
