using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class HealthController : MonoBehaviour
{
    public Image healthBar;
    public int maxHealth = 1000;
    public int health = 1000;
    float ratio = 1f;

    protected void Start()
    {
        if (!healthBar) 
        {
            var healthBarObject = transform.Find("Canvas").Find("Image_Health");
            healthBar = healthBarObject.GetComponent<Image>();
        }
        CalculateRatio();
    }
    void Update()
    {
        
    }
    void CalculateRatio()
    {
        ratio = (float)health / maxHealth;
        healthBar.fillAmount = ratio;
    }
    public virtual void ApplyDamage(int damage)
    {
        Debug.Log("ApplyDamage - " + this.gameObject);
        if(health > damage)
        {
            health -= damage;
        }
        else
        {
            health = 0;
            ApplyDeath();
        }
        CalculateRatio();
    }
    public abstract void ApplyDeath();


    
}
