using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private TextMeshProUGUI tutorialText;
    
    private static TutorialManager _shared;

    public static int START = -1;
    public static int LOOK = 0;
    public static int MOVE = 1;
    public static int SHOOT = 2;
    public static int AIM = 3;
    public static int RESPAWN = 4;
    public static int INTERACT = 5;
    
    public static int IN_GAME = 10;

    private static String[] texts = new[]
    {
        "Move the mouse to Look around\n\n(Turn 90 degrees to continue)",
        "Press WASD to move around",
        "Press the left mouse button to shoot a color balloon\n\n(Hold for rapid fire)",
        "Hold the right mouse button to zoom in",
        "Unity wheel physics are hard... Sometimes things go wrong!\n\nPress the middle mouse button to respawn to nearest respawn point",
        "Press the space bar to interact with objects\n\nInteract with the green gate thingy to start the game!"
    };
    
    private int state;
    private AsyncOperation asyncOperation;

    private float start;
    private float wait = 1;
    private int nextState;

    private void Awake()
    {
        if (_shared == null)
        {
            _shared = this;
            State = LOOK;
            StartCoroutine(_shared.LoadScene());
        }
    }

    private void Update()
    {
        if (wait > 0)
        {
            wait -= Time.deltaTime;
            if (wait <= 0)
            {
                _shared.state = nextState;
                _shared.tutorialText.gameObject.SetActive(true);
            }
        }
    }

    public static int State
    {
        get => (_shared != null) ? _shared.state : IN_GAME;
        set
        {
            if (_shared != null)
            {
                _shared.tutorialText.gameObject.SetActive(false);
                if (value > START && value < IN_GAME)
                {
                    _shared.nextState = value;
                    _shared.tutorialText.text = texts[value];
                    _shared.wait = 1;
                }
                else
                {
                    _shared.state = value;
                }
            }
        }
    }

    public static void StartGame()
    {
        State = IN_GAME;
        _shared.asyncOperation.allowSceneActivation = true;
    }
    
    private IEnumerator LoadScene()
    {
        yield return null;

        //Begin to load the Scene you specify
        asyncOperation = SceneManager.LoadSceneAsync("Worlds");
        
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;

        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            progressText.text = "Loading Game: " + (asyncOperation.progress * 100) + "%";
        }

        progressText.text = "Loading Game: 100%";
        yield return null;
    }
}
