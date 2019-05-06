using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;


public class QuizManager : Trigger
{
 //Created an array of Questions that need to be filled in the inspactor
  public Question[] questions;
  private static List<Question> unansweredQuestions;

  private Question currentQuestion;

  [SerializeField]
  private Text factText;

   [SerializeField]
   private float timeBetweenQuestions = 1f;

   public GameObject questionHolder;
   
  void Start()
  {
      // when game starts for the first time they need to be loaded in into a list of unanswered Questions 
      /*if(unansweredQuestions == null || unansweredQuestions.Count == 0)
      {
          unansweredQuestions = questions.ToList<Question>();
      }

      SetCurrentQuestion(); */
      questionHolder.SetActive (false);
  }
  void SetCurrentQuestion()
  {
      int randomQUestionIndex = Random.Range(0 , unansweredQuestions.Count);
      currentQuestion = unansweredQuestions[randomQUestionIndex];

      factText.text = currentQuestion.fact;

      unansweredQuestions.RemoveAt (randomQUestionIndex);
  }

  IEnumerator transitionToNextQuestion ()
  {
      unansweredQuestions.Remove(currentQuestion);

      yield return new WaitForSeconds(timeBetweenQuestions);
      gameObject.SetActive(false);
      //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  public void IsCorrect(bool isCorrect)
  {
    if(isCorrect)
    {
        Debug.Log("CORRECT!");
        OnCorrect();
    }
    else
    {
        Debug.Log("WRONG!");
    }
  }

  public override void Activate()
  {

  }

  public override void Deactivate()
  {
      questionHolder.SetActive(false);
      base.Deactivate();
  }

    protected override void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            if(unansweredQuestions == null || unansweredQuestions.Count == 0)
            {
                unansweredQuestions = questions.ToList<Question>();
            }
            questionHolder.SetActive (true);
            SetCurrentQuestion();
        }
       
    }
    
    protected override void OnTriggerExit(Collider col)
    {   
        if(col.CompareTag("Player"))
        {
            questionHolder.SetActive (false);
        }
    }
}
