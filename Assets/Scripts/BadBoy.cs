using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBoy : MonoBehaviour
{
    public int speed;    
    public Animator anim;
    [SerializeField] private LayerMask ground;
    [SerializeField] private bool facingLeft;
    [SerializeField] private Collider2D checkNextPos;
    public int dir = -1;



    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Down")
        {
            GameController.puntos += 100;
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            ChangeDirection();
            
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Skill")
        {
            GameController.puntos += 100;
            Destroy(this.gameObject);
        }
    }

    private void Movement()
    {
        this.transform.position += new Vector3(dir*speed*Time.deltaTime,0,0);

        if (dir == -1)
        {
            if (!checkNextPos.IsTouchingLayers(ground))
            {
                
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                dir = dir * -1;
            }
        }
        else if (dir == 1)
        {
            if (!checkNextPos.IsTouchingLayers(ground))
            {
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                dir = dir * -1;
            }
        } 
    }

    private void ChangeDirection()
    {
        if (facingLeft == true)
        {
            facingLeft = false;
        }
        else
        {
            facingLeft = true;
        }
    }    


}
