using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public Vector3 MoveBy;



    public float waitTime;
    public float timeToReach;

    private float time_to_wait;
    private bool going_to_a;
    private bool wait;
    private Vector3 pointA;
    private Vector3 pointB;


    private Rigidbody2D myBody;




    // Use this for initialization
    void Start()
    {
        this.pointA = this.transform.position;
        this.pointB = this.pointA + MoveBy;
        this.time_to_wait = waitTime;
        this.going_to_a = false;
        this.wait = true;
        myBody = GetComponent<Rigidbody2D>();
    }

    bool isArrived(Vector3 pos, Vector3 target)
    {
        pos.z = 0;
        target.z = 0;
        return Vector3.Distance(pos, target) < 0.02f;
    }


    // Update is called once per frame
    void Update()
    {

        
    }



    void FixedUpdate()
    {
        Vector3 my_pos = this.transform.position;
        Vector3 target;

        if (going_to_a)
        {
            target = this.pointA;
        }
        else
        {
            target = this.pointB;
        }
        
        Vector3 destination = target - my_pos;

        destination.z = 0;
        if (wait)
        {
            time_to_wait -= Time.deltaTime;

            if (!(time_to_wait <= 0)) return;

            time_to_wait = waitTime;

            wait = false;


            myBody.velocity = new Vector2(destination.x / timeToReach, destination.y / timeToReach);
           
            return;
        }

        if (isArrived(my_pos, target) == false) return;
        going_to_a = !going_to_a;
        wait = true;
        myBody.velocity = new Vector2(0, 0);







       

    }
}