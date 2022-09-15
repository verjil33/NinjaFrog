using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall : MonoBehaviour
{
    [SerializeField] private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       this.transform.position += Vector3.down * 10 * Time.deltaTime;
       this.transform.Rotate(new Vector3(0, 0, -2));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Down")
        {                        
            SceneManager.LoadScene(sceneName);
        }
    }
}
