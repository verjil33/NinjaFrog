﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    [SerializeField] private string menu;
    // Start is called before the first frame update
    public void BackMenu()
    {
        SceneManager.LoadScene(menu);
    } 
}
