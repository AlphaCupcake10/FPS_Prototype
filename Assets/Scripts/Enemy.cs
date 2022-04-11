using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP = 100;
    RagdollController ragdollController;
    void Start()
    {
        ragdollController = GetComponent<RagdollController>();
    }
    public void TakeDamage(float Damage)
    {
        HP -= Damage;
        if(HP<=0)
        {
            if(ragdollController != null)
                ragdollController.Enable();
        }
    }
}
