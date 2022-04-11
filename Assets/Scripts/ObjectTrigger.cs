using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectTrigger : MonoBehaviour
{
    public UnityEvent TriggerEvent;
    public LayerMask Player;

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Trigger");
        TriggerEvent.Invoke();
    }
}
