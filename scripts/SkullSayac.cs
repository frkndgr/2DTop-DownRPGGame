using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkullSayac : MonoBehaviour
{
    [SerializeField]private Text skullText;
    public int skullSayacı;
    public GameObject boss;
    public GameObject bosshealth;
    
    void Start()
    {
        
    }
    void Update()
    {
        
        bossFight();
        
    }


    public void AddCurrency(skull currency)
    {
        if (currency.currentObject == skull.PickupObject.skull)
        {
            skullSayacı += currency.pickupQuantity;
            skullText.text = skullSayacı.ToString() + " / " + "5";
        }
    }
    
    public void bossFight()
    {
        if (skullSayacı ==5)
        {
            boss.SetActive(true);
            bosshealth.SetActive(true);
        }
    }

    
}
