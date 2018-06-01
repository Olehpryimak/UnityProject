using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    protected virtual void OnRabitHit(Hero rabit)
    {
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        
            Hero rabit = collider.GetComponent<Hero>();
            if (rabit != null)
            {
                this.OnRabitHit(rabit);
            }
        
    }
    public void CollectedHide()
    {
        Destroy(this.gameObject);
    }
}