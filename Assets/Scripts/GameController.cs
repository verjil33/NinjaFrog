using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static int puntos = 0;
    public static int life = 3;
    [SerializeField] private Text textoPuntos;
    [SerializeField] private Text textoVidas;
    [SerializeField] private string loseScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPoints();
        CheckLife();
        //skillPool.SetearFalse();
    }

    void CheckPoints()
    {
        textoPuntos.text = puntos.ToString();

    }
    private void CheckLife()
    {
        textoVidas.text = life.ToString();
        if (life <= 0)
        {
            SceneManager.LoadScene(loseScene);
        }
    }
}
