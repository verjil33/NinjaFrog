using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillActor : MonoBehaviour
{
    
    private int time = 0;    
    [SerializeField] private float speed;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time++;
        Movement();
        CheckLife();
    }

    private void Movement()
    {
        this.transform.position += this.transform.right * speed * Time.deltaTime;       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            this.gameObject.SetActive(false);
            Debug.Log("HIT");

        }
    }



    void CheckLife()
    {
        if (time == 300)
        {
            this.gameObject.SetActive(false);
            time = 0;
        }
    }
}
