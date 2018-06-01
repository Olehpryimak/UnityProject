using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Collectable
{
    protected override void OnRabitHit(Hero rabit)
    {

        this.CollectedHide();
    }
}
