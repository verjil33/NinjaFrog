using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] public string start;
    
    [SerializeField] public string controls;

    private void Start()
    {
        GameController.life = 3;
        GameController.puntos = 0;

    }


    public void StartGame()
    {
        SceneManager.LoadScene(start);
    }

    public void EndGame()
    {
        Application.Quit();
        Debug.Log("Quit Succes");
    }
    public void Controls()
    {
        SceneManager.LoadScene(controls);

    }



}
