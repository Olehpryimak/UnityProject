using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Collectable
{
    bool used = false;
    protected override void OnRabitHit(Hero rabit)
    {
        if (used == false)
        {
            rabit.transform.localScale = new Vector3(rabit.transform.localScale.x * 2, rabit.transform.localScale.y * 2);
            used = true;
        }
        this.CollectedHide();
    }
}

