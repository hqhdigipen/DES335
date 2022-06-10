using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharScript : MonoBehaviour
{
    public int maxHealth = 100;
    public int setCurrentHealth;
    int currentHealth;

    float typeAdvantageMod = 1.25f;
    float typeWeaknessMod = 0.75f;
    public enum ElementType { Fire, Water, Earth }
    public ElementType elementType;

    public HealthBarScript healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);

        if (setCurrentHealth <= 0)
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }
        else
        {
            currentHealth = setCurrentHealth;
            healthBar.SetHealth(currentHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20, "Fire");
        }
    }

    public void TakeDamage(int damage, string atkElement)
    {
        switch (elementType.ToString())
        {
            case "Fire":
                switch (atkElement)
                {
                    case "Fire":
                        currentHealth -= damage;
                        break;
                    case "Water":
                        currentHealth -= Mathf.FloorToInt(damage * typeAdvantageMod);
                        break;
                    case "Earth":
                        currentHealth -= Mathf.FloorToInt(damage * typeWeaknessMod);
                        break;
                }
                break;
            case "Water":
                switch (atkElement)
                {
                    case "Fire":
                        currentHealth -= Mathf.FloorToInt(damage * typeWeaknessMod);
                        break;
                    case "Water":
                        currentHealth -= damage;
                        break;
                    case "Earth":
                        currentHealth -= Mathf.FloorToInt(damage * typeAdvantageMod);
                        break;
                }
                break;
            case "Earth":
                switch (atkElement)
                {
                    case "Fire":
                        currentHealth -= Mathf.FloorToInt(damage * typeAdvantageMod);
                        break;
                    case "Water":
                        currentHealth -= Mathf.FloorToInt(damage * typeWeaknessMod);
                        break;
                    case "Earth":
                        currentHealth -= damage;
                        break;
                }
                break;

        }

        healthBar.SetHealth(currentHealth);
    }
}
