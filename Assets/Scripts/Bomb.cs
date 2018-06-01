using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bomb : Collectable
{
    protected override void OnRabitHit(Hero rabit)
    {
        if (rabit.transform.localScale.x > rabit.StartSize().x)
        {
            rabit.transform.localScale = new Vector3(rabit.transform.localScale.x / 2, rabit.transform.localScale.y / 2);


        }
        else
        {

            rabit.Die();
        }

        this.CollectedHide();
    }
}
