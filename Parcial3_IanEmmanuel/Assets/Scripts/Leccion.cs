using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Se guarda la información, se almacena y se puede hacer uso de estas. 
/// </summary>
[System.Serializable]
public class Leccion
{
    //Se guarda el núm. de lección
    public int ID;
    //Se almacena la pregunta
    public string lessons;
    //Almacén para respuestas
    public List<string> options;
    //Respuesta correcta
    public int correctAnswer;
}
