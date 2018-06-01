using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gem : Collectable
{
    protected override void OnRabitHit(Hero rabit)
    {

        this.CollectedHide();
    }
}

