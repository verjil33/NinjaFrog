using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBoy : MonoBehaviour
{
    public int speed;
    [SerializeField] private GameObject leftWall;
    [SerializeField] private GameObject rightWall;   
    public Animator anim;
    [SerializeField] private Collider2D collider;
    [SerializeField] private LayerMask ground;
    [SerializeField] private bool facingLeft;


    private void Start()
    {
        collider = GetComponent<Collider2D>();
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
        if (facingLeft)
        {
            if (this.transform.position.x > leftWall.transform.position.x)
            {
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1, 1);                    
                }
                if (collider.IsTouchingLayers(ground))
                {
                    this.transform.position += Vector3.left * speed * Time.deltaTime;
                } 
            }
            else facingLeft = false;
        }
        else
        {
            if (this.transform.position.x < rightWall.transform.position.x)
            {
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                if (collider.IsTouchingLayers(ground))
                {
                    this.transform.position += Vector3.right * speed * Time.deltaTime;
                }                               
            }
            else facingLeft = true;  
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
