using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Trigger : InteractableObject
{
    public InteractableObject[] objects;

    protected abstract void OnTriggerEnter(Collider col);

    protected abstract void OnTriggerExit(Collider col);

    public override void Deactivate()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCorrect()
    {
        foreach (InteractableObject obj in objects)
        {
            Debug.Log(obj.name);
            obj.Activate();
        }
        Deactivate();
    }
}
