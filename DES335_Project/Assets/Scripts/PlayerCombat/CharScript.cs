using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharScript : MonoBehaviour
{
    public int maxHealth = 100;
    public int setCurrentHealth;
    public int currentHealth;
    int tempCal;

    float typeAdvantageMod = 1.25f;
    float typeWeaknessMod = 0.75f;
    public enum ElementType { Fire, Water, Earth }
    public ElementType elementType;

    public HealthBarScript healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);

        if (setCurrentHealth < 0)
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
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }

        healthBar.SetHealth(currentHealth);
    }

    public int TakeDamage(int damage, string atkElement)
    {
        switch (elementType.ToString())
        {
            case "Fire":
                switch (atkElement)
                {
                    case "Fire":
                        currentHealth -= damage;
                        tempCal = damage;
                        break;
                    case "Water":
                        currentHealth -= Mathf.FloorToInt(damage * typeAdvantageMod);
                        tempCal = Mathf.FloorToInt(damage * typeAdvantageMod);
                        break;
                    case "Earth":
                        currentHealth -= Mathf.FloorToInt(damage * typeWeaknessMod);
                        tempCal = Mathf.FloorToInt(damage * typeWeaknessMod);
                        break;
                    case "Normal":
                        currentHealth -= damage;
                        tempCal = damage;
                        break;
                }
                break;
            case "Water":
                switch (atkElement)
                {
                    case "Fire":
                        currentHealth -= Mathf.FloorToInt(damage * typeWeaknessMod);
                        tempCal = Mathf.FloorToInt(damage * typeWeaknessMod);
                        break;
                    case "Water":
                        currentHealth -= damage;
                        tempCal = damage;
                        break;
                    case "Earth":
                        currentHealth -= Mathf.FloorToInt(damage * typeAdvantageMod);
                        tempCal = Mathf.FloorToInt(damage * typeAdvantageMod);
                        break;
                    case "Normal":
                        currentHealth -= damage;
                        tempCal = damage;
                        break;
                }
                break;
            case "Earth":
                switch (atkElement)
                {
                    case "Fire":
                        currentHealth -= Mathf.FloorToInt(damage * typeAdvantageMod);
                        tempCal = Mathf.FloorToInt(damage * typeAdvantageMod);
                        break;
                    case "Water":
                        currentHealth -= Mathf.FloorToInt(damage * typeWeaknessMod);
                        tempCal = Mathf.FloorToInt(damage * typeWeaknessMod);
                        break;
                    case "Earth":
                        currentHealth -= damage;
                        tempCal = damage;
                        break;
                    case "Normal":
                        currentHealth -= damage;
                        tempCal = damage;
                        break;
                }
                break;
            case "Normal":
                switch (atkElement)
                {
                    case "Fire":
                        currentHealth -= damage;
                        tempCal = damage;
                        break;
                    case "Water":
                        currentHealth -= damage;
                        tempCal = damage;
                        break;
                    case "Earth":
                        currentHealth -= damage;
                        tempCal = damage;
                        break;
                    case "Normal":
                        currentHealth -= damage;
                        tempCal = damage;
                        break;
                }
                break;
        }

        healthBar.SetHealth(currentHealth);

        if (this.gameObject.tag == "Player" || this.gameObject.tag == "Companion")
        {
            StartCoroutine(Blink(0.5f));
        }
        return tempCal;
    }

    public  void SetHPinUI()
    {
        healthBar.SetHealth(currentHealth);
    }

    IEnumerator Blink(float waitTime)
    {

        Image image = this.gameObject.GetComponent<Image>();

        var endTime = Time.time + waitTime;

        while (Time.time < endTime)
        {
            switch (image.color.a.ToString())
            {
                case "0":
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
                    //Play sound
                    yield return new WaitForSeconds(0.1f);
                    break;
                case "1":
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
                    //Play sound
                    yield return new WaitForSeconds(0.1f);
                    break;
            }
        }

        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
    }
}
