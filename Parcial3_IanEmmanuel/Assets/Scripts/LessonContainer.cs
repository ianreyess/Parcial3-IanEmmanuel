using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// La clase gestiona las lecciones, se encarga de lo que aparece en la ui con as preguntas y respuestas ya guardadas. 
/// </summary>
public class LessonContainer : MonoBehaviour
{
    //Variable que configura la lección
    //Header= clasifica y separa las variables en el inspector.
    [Header("GameObject Configuration")]
    public int lection = 0;
    public int currentLession = 0;
    public int totalLession = 0;
    public bool areAllLessonsComplete = false;
    //Configura la interfaz de usuario
    [Header("UI Configuration")]
    public TMP_Text stageTitle;
    public TMP_Text lessonStage;

    [Header("External GameObject Configuration")]
    //Configuracion de la imagen principal 
    public GameObject lessonContainer;

    [Header("Lesson Data")]
    public ScriptableObject lessonData;
    public string LessonName;


    void Start()
    {
        //Verifica que la imagen sí esté ligado al inspector.
        if(lessonContainer != null)
        {
            OnUpdateUI();
        }
        else
        {
            Debug.LogWarning("GameObject Nulo, revisa las variables de tipo GameObject lessonContainer");
        }
    }

    
    public void OnUpdateUI()
    {
        //Verifica que el texto esté ligado al inspector.
        if(stageTitle != null || lessonContainer != null) 
        {
            stageTitle.text = "Leccion " + lection;
            lessonStage.text = "Leccion " + currentLession + " de " + totalLession;
        }
        else
        {
            Debug.LogWarning("GameObject Nulo, revisa las variable de tipo TMP_Text");
        }
    }

    public void EnableWindow()
    {
        OnUpdateUI();
                            //activeSelf verifica que esté activo
        if(lessonContainer.activeSelf)
        {
            //Lo desacctiva.
            lessonContainer.SetActive(false);
        }
        else
        {
            lessonContainer.SetActive(true);
            MainScript.instance.SetSelectedLesson(LessonName);
        }
    }
}
