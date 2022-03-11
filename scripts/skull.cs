using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skull : MonoBehaviour
{
    
    public enum PickupObject{skull};
    public PickupObject currentObject;
    public int pickupQuantity;
    public SkullSayac skullSayac;
    
    
    private void OnTriggerEnter2D(Collider2D other) 
    {

        if (other.CompareTag("Player"))
        {
            skullSayac.AddCurrency(this);
            Destroy(gameObject);
            
        }

        
        
    }
}
