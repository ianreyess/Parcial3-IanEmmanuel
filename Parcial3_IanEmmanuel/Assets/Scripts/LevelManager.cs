using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [Header("Level Data")]
    public SubjectContainer subject;

    [Header("User Interface")]
    public TMP_Text QuestionTxt;
    public TMP_Text livesTxt;
    public List<OptionBtm> Options;
    public GameObject CheckButton;
    public GameObject AnswerContainer;
    public Color Green;
    public Color Red;

    [Header("Game Configuration")]
    public int questionAmount = 0;
    public int currentQuestion = 0;
    public string question;
    public string correctAnswer;
    public int answerFromPlayer;
    public int lives = 5;

    [Header("Current Lesson")]
    public Leccion currentLesson;

    private void Awake()
    {
        if(Instance != null)
        {
            return;
        }
        else
        {
            Instance = this;
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Main");
    }

    void Start()
    {
        subject = SaveSystem.Instance.subject;
        //Se establece la cantidad de preguntas.
        questionAmount = subject.leccionList.Count;
        //Primera pregunta.
        LoadQuestion();
        CheckPlayerState();
    }
    
    private void LoadQuestion()
    {   
        if(currentQuestion < questionAmount) 
        {
            //Establece la lección actual.
            currentLesson = subject.leccionList[currentQuestion];
            question = currentLesson.lessons;
            correctAnswer = currentLesson.options[currentLesson.correctAnswer];
            QuestionTxt.text = question;
            Options[0].GetComponent<OptionBtm>().OptionName = currentLesson.options[0];
            for(int i = 0; i < currentLesson.options.Count; i++)
            {
                Options[i].GetComponent<OptionBtm>().OptionName = currentLesson.options[i];
                Options[i].GetComponent<OptionBtm>().OptionID = i;
                Options[i].GetComponent<OptionBtm>().UpdateText();
            }
        }
        else
        {
            Debug.Log("Fin de las preguntas");
           
        }
    }


    public void NextCuestion()
    {
        if(CheckPlayerState())
        {
            if (currentQuestion < questionAmount)
            {
                //Revisa que la pregunta sea correcta o no.
                bool isCorrect = currentLesson.options[answerFromPlayer] == correctAnswer;

                AnswerContainer.SetActive(true);

                if(isCorrect)
                {
                    AnswerContainer.GetComponent<Image>().color = Green;
                    Debug.Log("Respuesta correcta. " + question + ": " + correctAnswer);
                }
                else
                {
                    lives--;
                    AnswerContainer.GetComponent<Image>().color = Red;
                    Debug.Log("Respuesta incorrecta. " + question + ": " + correctAnswer);

                }
                //Actualiza la vidas.
                livesTxt.text = lives.ToString();

                currentQuestion++;

                StartCoroutine(ShowResultAndLoadQuestion(isCorrect));

                answerFromPlayer = 9;
            }
            else
            {
    
            }
        }
    }

    private IEnumerator ShowResultAndLoadQuestion(bool isCorrect)
    {
        yield return new WaitForSeconds(2.5f); //Ajusta el tiempo que deseas mostrar el resultado

        AnswerContainer.SetActive(false);

        //Carga la sig. Pregunta.
        LoadQuestion();

        CheckPlayerState();
    }

    public void SetPlayerAnswer(int _answer)
    {
        answerFromPlayer = _answer;
    }

    public bool CheckPlayerState()
    {
        if(answerFromPlayer != 9)
        {
            CheckButton.GetComponent<Button>().interactable = true;
            CheckButton.GetComponent<Image>().color = Color.white;
            return true;
        }
        else
        {
            CheckButton.GetComponent<Button>().interactable = true;
            CheckButton.GetComponent<Image>().color = Color.grey;
            return false;

        }
    }
}
