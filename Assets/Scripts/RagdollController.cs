using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class RagdollController : MonoBehaviour
{
    Rigidbody RB;
    Rigidbody[] RBs;
    Collider[] colliders;
    public Collider BaseCollider;
    Animator animator;
    void Start()
    {
        RBs = GetComponentsInChildren<Rigidbody>();
        colliders = GetComponentsInChildren<Collider>();
        animator = GetComponent<Animator>();
        RB = GetComponent<Rigidbody>();
        Disable();
    }
    public void Enable()
    {
        foreach(Rigidbody rb in RBs)
        {
            rb.isKinematic = false;
            rb.detectCollisions = true;
        }
        foreach(Collider col in colliders)
        {
            col.enabled = true;
        }
        RB.isKinematic = true;
        animator.enabled = false;
        BaseCollider.enabled = false;
    }
    public void Disable()
    {
        foreach(Rigidbody rb in RBs)
        {
            rb.isKinematic = true;
            rb.detectCollisions = true;
        }
        foreach(Collider col in colliders)
        {
            //col.enabled = false;
        }
        RB.isKinematic = false;
        animator.enabled = true;
        BaseCollider.enabled = true;
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.T))
            Enable();
        if(Input.GetKey(KeyCode.Y))
            Disable();
    }
}
