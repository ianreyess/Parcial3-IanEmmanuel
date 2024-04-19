using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public static MainScript instance;
    public string SelectedLesson = "dummy";

    [Header("External GameObject Configuration")]
    public GameObject creditos;
    public GameObject cofre;
    public GameObject uno;
    public GameObject dos;


    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        else
        {
            instance = this;
        }
    }

    public void SetSelectedLesson(string lesson)
    {
        SelectedLesson = lesson;
        PlayerPrefs.SetString("SelectedLesson", SelectedLesson);
    }

    public void BeginGame()
    {
        SceneManager.LoadScene("Lesson");
    }

    public void DatesInteresting()
    {
        SceneManager.LoadScene("Novedades");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Main");
    }

    public void EnableWindow()
    {
        //activeSelf es si está activado
        if (creditos.activeSelf)
        {
            //desactiva el objeto si está activo
            creditos.SetActive(false);
        }
        else
        {
            //Lo activa en caso de que esté desactivado.
            creditos.SetActive(true);
        }
    }
    public void One()
    {
        if (uno.activeSelf)
        {
            uno.SetActive(false);
        }
        else
        {
            uno.SetActive(true);
        }
    }

    public void Dos()
    {
        if (dos.activeSelf)
        {
            dos.SetActive(false);
        }
        else
        {
            dos.SetActive(true);
        }
    }

    public void Cofre()
    {
        if (cofre.activeSelf)
        {
            cofre.SetActive(false);
        }
        else
        {
            cofre.SetActive(true);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
