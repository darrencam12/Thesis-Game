using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlatform : InteractableObject
{
    public bool hideOnStart = false;

    public bool showIfCorrect = true;

    void Start()
    {
        if (hideOnStart) Deactivate();
    }

    public override void Activate()
    {
        gameObject.SetActive(showIfCorrect);
    }

    public override void Deactivate()
    {
        gameObject.SetActive(!showIfCorrect);
    }

}
