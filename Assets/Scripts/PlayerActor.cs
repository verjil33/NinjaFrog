using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerActor : MonoBehaviour
{
    [SerializeField] private string anotherTry;
    public Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    public int jump = 2;
    [SerializeField] private Pool skillPool;
    private bool facingRight = true;
    private float directionX;
    private float directionY;
    private Collider2D coll;
    [SerializeField] private LayerMask ground;
    public enum State { idle, run, jump, fall, dead }
    public GameObject shooter;
    private Vector3 direction;

    public State state = State.idle;
    public Animator anim;
    
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();        
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        
    }
    
    // Update is called once per frame
    void Update()
    {        
        Movement();
        Shoot();
        Parar();
        directionX = Input.GetAxis("Horizontal");
        
       
    }
    

    private void Movement()
    {
        if (directionX < 0)
        {
            Debug.Log("moviendo izquierda");
            //this.transform.position -= new Vector3(speed * Time.deltaTime, this.transform.position.y);
            rb.velocity = new Vector2(-speed, transform.position.y);
            transform.localScale = new Vector2(-1, 1);

            if (state !=State.jump && state != State.fall)
            {
                state = State.run;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            facingRight = false;
        }
        else if (directionX > 0)
        {
            Debug.Log("moviendo derecha");

            rb.velocity = new Vector2(speed, transform.position.y);
            transform.localScale = new Vector2(1, 1);
            facingRight = true;

            if (state != State.jump && state != State.fall)
            {
                state = State.run;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            }
        }
        else if (directionX == 0 && directionY == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            if (coll.IsTouchingLayers(ground) && state != State.jump && state != State.fall)
            {
                state = State.idle;
            }
           
        }

        if (Input.GetKeyDown(KeyCode.W) && coll.IsTouchingLayers(ground))
        {
            if (coll.IsTouchingLayers(ground))
            {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }

            state = State.jump;
            rb.velocity = new Vector2(rb.velocity.x, speed * jump);

        }
        //Debug.Log(state);
        anim.SetInteger("state", (int)state);
        StateChanger();
    }

    private void Parar()
    {
        if (Input.GetKeyDown(KeyCode.S) && coll.IsTouchingLayers(ground))
        {            
            rb.rotation = 0;
            state = State.idle;
        }
    }


    private void StateChanger()
    {
        if(state == State.jump)
        {
            if(rb.velocity.y < 0)
            {
                //Debug.Log("F");
                state = State.fall;
            }
        }
        else if(state == State.fall)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }            
        } 
        else if(Mathf.Abs(rb.velocity.x) > 0)
        {            
            state = State.run;
        }
        else
        {
            state = State.idle;
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (facingRight)
            {                
                skillPool.PoolRequest(shooter.transform.position, this.transform.rotation);
            }
            else
            {
                this.transform.rotation = new Quaternion(0, -1, 0, 0);
                skillPool.PoolRequest(shooter.transform.position, this.transform.rotation);
                this.transform.rotation = new Quaternion(0, 0, 0, 0);
            }  
        }
    }  
  
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Down")
        {      
            
            SceneManager.LoadScene(anotherTry);
            GameController.life--;
            GameController.puntos = 0;

        }
    }
    
}
