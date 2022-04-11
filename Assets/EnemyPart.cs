using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPart : MonoBehaviour
{
    Rigidbody RB;
    public float DamagePercent = 100;
    public Enemy enemy;
    void Awake()
    {
        RB = GetComponent<Rigidbody>();
        enemy = GetComponentInParent<Enemy>();
    }
    public void TakeDamage(float Damage,Vector3 NormalForce)
    {
        Debug.Log(Damage * DamagePercent/100);
        enemy.TakeDamage(Damage * DamagePercent/100);
        RB.AddForce(NormalForce,ForceMode.Impulse);
    }
}
