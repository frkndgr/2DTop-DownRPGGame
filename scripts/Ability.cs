using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    public Image abilityImage;
    public float cooldown = 5f;
    bool isCooldown = false;
    public KeyCode Q;
    void Start()
    {
        abilityImage.fillAmount = 0;
    }

    
    void Update()
    {
        Ability1();
    }

    void Ability1()
    {
        if (Input.GetKey(Q) && isCooldown == false)
        {
            isCooldown = true;
            abilityImage.fillAmount = 1;
        }

        if (isCooldown)
        {
            abilityImage.fillAmount -= 1 / cooldown * Time.deltaTime;

            if (abilityImage.fillAmount <= 0)
            {
                abilityImage.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
}
