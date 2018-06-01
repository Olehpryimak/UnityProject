using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

    public float speed = 1;
    bool isGrounded = false;
    float dieTime = 1f;
    float currentDieTime = 0;
    bool JumpActive = false;
    Transform heroParent = null;
    float JumpTime = 0f;
    public float MaxJumpTime = 2f;
    public float JumpSpeed = 2f;
    Rigidbody2D myBody = null;
    private Vector3 startSize;
    Animator animator ;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        startSize = this.transform.localScale;
        myBody = this.GetComponent<Rigidbody2D>();
        LevelController.current.setStartPosition(myBody.transform.position);
        this.heroParent = this.transform.parent;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void FixedUpdate()
    {

        float value = Input.GetAxis("Horizontal");







        Vector3 from = transform.position + Vector3.up * 0.3f;
        Vector3 to = transform.position + Vector3.down * 0.1f;
        int layer_id = 1 << LayerMask.NameToLayer("Ground");
        RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
        if (hit)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        Debug.DrawLine(from, to, Color.red);




        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            this.JumpActive = true;
        }
        if (this.JumpActive)
        {
            //Якщо кнопку ще тримають
            if (Input.GetButton("Jump"))
            {
                this.JumpTime += Time.deltaTime;
                if (this.JumpTime < this.MaxJumpTime)
                {
                    Vector2 vel = myBody.velocity;
                    vel.y = JumpSpeed * (1.0f - JumpTime / MaxJumpTime);
                    myBody.velocity = vel;
                }
            }
            else
            {
                this.JumpActive = false;
                this.JumpTime = 0;
            }
        }











        





        if (this.isGrounded)
        {
            animator.SetBool("jump", false);
        }
        else
        {
            animator.SetBool("jump", true);
        }
        if (Mathf.Abs(value) > 0)
        {
            Vector2 vel = myBody.velocity;
            vel.x = value * speed;


            myBody.velocity = vel;

            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }




        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (value < 0)
        {
            sr.flipX = true;
        }
        else if (value > 0)
        {
            sr.flipX = false;
        }



        RaycastHit2D hit1 = Physics2D.Linecast(from, to, layer_id);
        if (hit)
        {
            //Перевіряємо чи ми опинились на платформі
            if (hit.transform != null
            && hit.transform.GetComponent<Platform>() != null)
            {
                //Приліпаємо до платформи
                SetNewParent(this.transform, hit1.transform);
            }
        }
        else
        {
            //Ми в повітрі відліпаємо під платформи
            SetNewParent(this.transform, this.heroParent);
        }


        


        if (animator.GetBool("die"))
        {
            currentDieTime -= Time.deltaTime;
            if (currentDieTime <= 0)
            {
                LevelController.current.onRabitDeath(this);
                animator.SetBool("die",false);
                currentDieTime = dieTime;
            }
        }


    }

    
    

    static void SetNewParent(Transform obj, Transform new_parent)
    {
        if (obj.transform.parent != new_parent)
        {
            //Засікаємо позицію у Глобальних координатах
            Vector3 pos = obj.transform.position;
            //Встановлюємо нового батька
            obj.transform.parent = new_parent;
            //Після зміни батька координати кролика зміняться
            //Оскільки вони тепер відносно іншого об’єкта
            //повертаємо кролика в ті самі глобальні координати
            obj.transform.position = pos;
        }



        

    }




    public Vector3 StartSize()
    {

        return this.startSize;

    }

    public void Die()
    {

        animator.SetBool("die",true);
        currentDieTime = dieTime;


    }

}
