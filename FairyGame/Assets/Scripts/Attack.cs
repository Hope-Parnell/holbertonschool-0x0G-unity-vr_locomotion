using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPointWeapon;
    public void PlayerAttack()
    {
        GameObject projectile = GameObject.Instantiate(projectilePrefab, launchPointWeapon.position, launchPointWeapon.rotation) as GameObject;
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
		rb.AddForce(projectile.transform.forward * 1000);
    }
}
