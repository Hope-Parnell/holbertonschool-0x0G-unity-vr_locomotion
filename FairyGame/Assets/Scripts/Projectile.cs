using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float minDamage = 0f;
    public float maxDamage = 20f;
    void Awake()
    {
        Destroy(gameObject, 10.0f);
    }

    void OnTriggerEnter(Collider col){
        if (col.gameObject.tag != "Dead"){
            float dmg = Random.Range(minDamage, maxDamage);
            col.SendMessage("Damage", dmg);
            Debug.Log("Dealt" + dmg + "to" + col.gameObject.name);
        }
        Destroy(gameObject);
    }
    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag != "Weapon")
            Destroy(gameObject);

    }
}
