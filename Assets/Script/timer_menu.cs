using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer_menu : MonoBehaviour
{
    private void Start()
    {
        Invoke("CaricaMenu", 30f);
    }

    private void CaricaMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
