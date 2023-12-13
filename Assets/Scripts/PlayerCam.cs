
using UnityEngine;
using UnityEngine.UI;

public class PulleyMultiplicationQuiz : MonoBehaviour
{
    public Text questionText;
    public Button[] answerButtons;
    public Text resultText;

    private string[] questions = {
        "In a pulley system, if the effort force is 8 N and the mechanical advantage is 4, what is the load force?",
        "If a pulley system has 3 pulleys, and the effort force is 5 N, what is the total load force when neglecting friction?",
        // Add more questions as needed
    };

    private string[] correctAnswers = {
        "32 N",
        "15 N",
        // Add more correct answers as needed
    };

    private int currentQuestionIndex = 0;

    private void Start()
    {
        ShowQuestion();
    }

    private void ShowQuestion()
    {
        questionText.text = questions[currentQuestionIndex];

        for (int i = 0; i < answerButtons.Length; i++)
        {
            // Display answer options as multiples of the correct answer
            int answerValue = int.Parse(correctAnswers[currentQuestionIndex].Split(' ')[0]); // Extract the numerical value
            answerButtons[i].GetComponentInChildren<Text>().text = (answerValue * (i + 1)).ToString() + " N";
        }
    }

    public void CheckAnswer(string selectedAnswer)
    {
        if (selectedAnswer == correctAnswers[currentQuestionIndex])
        {
            resultText.text = "Correct!";
        }
        else
        {
            resultText.text = "Incorrect. The correct answer is: " + correctAnswers[currentQuestionIndex];
        }

        Invoke("NextQuestion", 2f);
    }

    private void NextQuestion()
    {
        resultText.text = "";
        currentQuestionIndex++;

        if (currentQuestionIndex < questions.Length)
        {
            ShowQuestion();
        }
        else
        {
            questionText.text = "Quiz completed!";
            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].gameObject.SetActive(false);
            }
        }
    }
}

