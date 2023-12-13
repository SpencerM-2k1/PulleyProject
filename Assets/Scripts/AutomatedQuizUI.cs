using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AutomatedQuizUI : MonoBehaviour
{
    public Canvas canvas; // Assign your canvas in the inspector
    public Font font; // Assign a font in the inspector

    private Text questionText;
    private Text feedbackText; // Text element to provide feedback
    private List<Button> optionButtons = new List<Button>();
    private Button submitButton;
    private Button startQuizButton; // Button to start the quiz
    private Button nextQuestionButton; // Button to load the next question
    private int selectedOption = -1;
    private int currentQuestionIndex = 0; // Index to keep track of the current question

    // Example question bank
    private List<(string Question, string[] Options, int CorrectAnswerIndex)> questionBank = new List<(string, string[], int)>
    {
        ("What is the primary purpose of a pulley system in a game?",
         new string[] { "To demonstrate physics principles", "To provide entertainment", "To create obstacles", "To simulate real-world scenarios" },
         0), // Correct answer: To demonstrate physics principles

        ("Which force is responsible for keeping a pulley system in equilibrium?",
         new string[] { "Tension force", "Gravitational force", "Normal force", "Frictional force" },
         0), // Correct answer: Tension force

        ("In a pulley system, what is the role of tension?",
         new string[] { "To transmit force through the ropes", "To add weight to the system", "To reduce the velocity of the pulley", "To transmit force through the ropes" },
         0), // Correct answer: Transmit force through the ropes

        ("If a pulley system is not moving, what can be said about the tension in the ropes?",
         new string[] { "Tension is the same throughout", "Tension is zero", "Tension varies with the angle of the rope", "Tension is only at the ends" },
         0), // Correct answer: Tension is the same throughout

        ("What is the relationship between the mechanical advantage of a pulley system and the number of ropes supporting the load?",
         new string[] { "Directly proportional", "Inversely proportional", "No relationship", "Exponential" },
         0), // Correct answer: Directly proportional
    };

    private (string Question, string[] Options, int CorrectAnswerIndex) currentQuestion;

    void Start()
    {
        if (canvas == null)
        {
            canvas = FindObjectOfType<Canvas>();
            if (canvas == null)
            {
                Debug.LogError("No Canvas found in the scene.");
                return;
            }
        }

        if (font == null)
        {
            font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        }

        // Create the start quiz button
        //startQuizButton = CreateButton("StartQuizButton", "Start Quiz", new Vector2(0, 0), new Vector2(200,50));
        //startQuizButton.onClick.AddListener(InitializeQuiz);
        startQuizButton = CreateButton("StartQuizButton", "Start Quiz", new Vector2(0, 0), new Vector2(200, 50));
        startQuizButton.onClick.AddListener(InitializeQuiz);
        startQuizButton.transform.localScale = new Vector3(1.0f,1.0f,1.0f);



        // Make the button sizable to Vector2(3, 3)
        startQuizButton.GetComponent<RectTransform>().sizeDelta = new Vector2(3, 3);




    }

    void test()
    {
        
    }

    void InitializeQuiz()
    {
        // Select the first question from the question bank
        currentQuestionIndex = 0;
        LoadQuestion(currentQuestionIndex);

        // Disable the start quiz button after clicking
        startQuizButton.gameObject.SetActive(false);
    }

    void LoadQuestion(int index)
    {
        // Clear previous question and options
        if (questionText != null) Destroy(questionText.gameObject);
        foreach (var button in optionButtons) Destroy(button.gameObject);
        optionButtons.Clear();
        if (feedbackText != null) feedbackText.gameObject.SetActive(false);
        if (submitButton != null) submitButton.gameObject.SetActive(false);
        if (nextQuestionButton != null) nextQuestionButton.gameObject.SetActive(false);

        // Select a new question from the question bank
        currentQuestion = questionBank[index];

        // Generate the quiz UI for the new question
        GenerateUI();
    }

    void GenerateUI()
    {
        // Create the question text
        questionText = CreateTextElement("QuestionText", currentQuestion.Question, new Vector2(0, 40), new Vector2(1, 1));

        // Create the answer buttons
        for (int i = 0; i < currentQuestion.Options.Length; i++)
        {
            Button optionButton = CreateButton("Option" + (i + 1), currentQuestion.Options[i], new Vector2(0, -30 - (i * 40)), new Vector2(1.5f, 1.5f));
            int index = i; // Local copy for the closure below
            optionButton.onClick.AddListener(() => OnOptionSelected(index));
            optionButtons.Add(optionButton);
        }

        // Create the submit button
        submitButton = CreateButton("SubmitButton", "Submit", new Vector2(0, -130), new Vector2(1.2f, 1.2f));
        submitButton.onClick.AddListener(OnSubmit);
        submitButton.interactable = false; // Start with the submit button disabled

        // Create the feedback text, initially empty and not visible
        feedbackText = CreateTextElement("FeedbackText", "", new Vector2(0, -170), new Vector2(0.8f, 0.8f));
        feedbackText.gameObject.SetActive(false); // Hide until needed

        // Create the next question button, but don't show it yet
        nextQuestionButton = CreateButton("NextQuestionButton", "Next Question", new Vector2(0, -220), new Vector2(1.5f, 1.5f));
        nextQuestionButton.onClick.AddListener(OnNextQuestion);
        nextQuestionButton.gameObject.SetActive(false); // Hide until needed
    }

    Text CreateTextElement(string name, string text, Vector2 position, Vector2 size)
    {
        GameObject textObj = new GameObject(name);
        textObj.transform.SetParent(canvas.transform);
        Text textComponent = textObj.AddComponent<Text>();
        textComponent.font = font;
        textComponent.text = text;
        textComponent.alignment = TextAnchor.MiddleCenter;
        textComponent.color = Color.black;

        RectTransform rectTransform = textObj.GetComponent<RectTransform>();
        rectTransform.sizeDelta = size;
        rectTransform.anchoredPosition = position;

        return textComponent;
    }

    Button CreateButton(string name, string buttonText, Vector2 position, Vector2 size)
    {
        GameObject buttonObj = new GameObject(name, typeof(Image), typeof(Button));
        buttonObj.transform.SetParent(canvas.transform);
        Button buttonComponent = buttonObj.GetComponent<Button>();
        buttonComponent.GetComponent<Image>().color = Color.white;

        RectTransform btnRect = buttonObj.GetComponent<RectTransform>();
        btnRect.sizeDelta = size;
        btnRect.anchoredPosition = position;

        // Create and set up the button's text
        Text btnText = new GameObject("Text").AddComponent<Text>();
        btnText.transform.SetParent(buttonObj.transform);
        btnText.font = font;
        btnText.text = buttonText;
        btnText.alignment = TextAnchor.MiddleCenter;
        btnText.color = Color.black;

        RectTransform textRect = btnText.GetComponent<RectTransform>();
        textRect.sizeDelta
        = size;
        textRect.anchoredPosition = Vector2.zero;

        return buttonComponent;
    }

    void OnOptionSelected(int optionIndex)
    {
        selectedOption = optionIndex;
        submitButton.interactable = true; // Enable the submit button when an option is selected

        // Provide visual feedback for the selected option
        foreach (var button in optionButtons)
        {
            button.interactable = true;
        }
        optionButtons[optionIndex].interactable = false;
    }

    void OnSubmit()
    {
        if (selectedOption < 0)
        {
            Debug.LogError("No option selected!");
        }
        else
        {
            // Check if the selected option is the correct one
            if (selectedOption == currentQuestion.CorrectAnswerIndex)
            {
                feedbackText.text = "Correct!";
                feedbackText.color = Color.green;
            }
            else
            {
                feedbackText.text = "Incorrect. The correct answer is: " + currentQuestion.Options[currentQuestion.CorrectAnswerIndex];
                feedbackText.color = Color.red;
            }

            feedbackText.gameObject.SetActive(true); // Show feedback text
            submitButton.interactable = false; // Optionally disable the submit button after answering
        }
        // Show the next question button if there are more questions
        if (currentQuestionIndex < questionBank.Count - 1)
        {
            nextQuestionButton.gameObject.SetActive(true);
        }
    }

    void OnNextQuestion()
    {
        // Increment the question index and load the next question
        if (currentQuestionIndex < questionBank.Count - 1)
        {
            currentQuestionIndex++;
            LoadQuestion(currentQuestionIndex);
        }
        else
        {
            // Optionally, handle the end of the quiz here
            Debug.Log("End of the quiz!");
        }
    }
}

