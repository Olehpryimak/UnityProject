using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHere : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter2D(Collider2D collider)
    {
        //Намагаємося отримати компонент кролика
        Hero rabit = collider.GetComponent<Hero>();
        //Впасти міг не тільки кролик
        if (rabit != null)
        {
            //Повідомляємо рівень, про смерть кролика
            LevelController.current.onRabitDeath(rabit);
        }
    }


}
