using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Este script nos saca del juego al interactuar con la imagen del boton "Exit"
/// </summary>
public class Exit : MonoBehaviour
{
    /// <summary>
    /// Este metodo reacciona al clic del mouse encima del boton emparentado  y nos saca del juego
    /// </summary>
    public void ExitGame()
    {
        // Si estamos en el editor de Unity
#if UNITY_EDITOR
        // Cierra el modo de reproducci�n
        UnityEditor.EditorApplication.isPlaying = false;
        // Si estamos en una compilaci�n del juego
#else
            // Cierra la aplicaci�n
            Application.Quit();
#endif
    }
}
