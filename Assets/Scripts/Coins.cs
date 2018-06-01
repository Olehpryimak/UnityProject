using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class Coins : Collectable
    {
        protected override void OnRabitHit(Hero rabit)
        {
           
            this.CollectedHide();
        }
    }


