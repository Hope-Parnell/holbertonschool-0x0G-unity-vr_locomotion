using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public float health = 100f;
    public float multiplier = 1.0f;
    public Slider healthBar;
    public TMP_Text healthText;
    public void Damage(float damage)
    {
        Transform parent = transform.parent;

        damage *= multiplier;
        Debug.Log("Got hit with " + damage + " damage");
        health -= damage;
        if (health < 0)
            health = 0;
        healthBar.value = health;
        healthText.text = $"Health: {health,5:N1}";
        if (health <= 0)
            SendMessage("GameOver");

        if ( parent != null )
        {
            parent.SendMessageUpwards("Damage", damage);
        }
    }
}
