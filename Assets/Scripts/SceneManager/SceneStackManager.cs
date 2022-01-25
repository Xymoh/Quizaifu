using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneStackManager : MonoBehaviour
{
    private float secondsToLoadNextScene = 0.1f;
    private int mainScene = 0;
    private int currentScene;
    private static int lastScene;

    public static Stack<int> sceneStack = new Stack<int>();

    public static SceneStackManager Instance;

    private void Awake()
    {
        
        DontDestroyOnLoad(this);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        currentScene = SceneManager.GetActiveScene().buildIndex;


    }

    private void OnLevelWasLoaded()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("I'm in: " + currentScene);

    }

    private void Update()
    {
        BackButtonPressed();


    }

    public void LoadNextScene(int numberOfSceneToLoad)
    {
        StartCoroutine(LoadScene(numberOfSceneToLoad));
    }

    private IEnumerator LoadScene(int numberOfScene)
    {
        SetLastScene(currentScene);

        yield return new WaitForSeconds(secondsToLoadNextScene);
        LoadNewScene(numberOfScene);
    }



    public void BackButtonPressed()
    {
        
        if (Input.GetKeyUp(KeyCode.Escape) && currentScene > mainScene) // Zamiennic na escape
        {
            if (lastScene == 0)
            {

                SceneManager.LoadScene(mainScene);
            }
            else
            {
                LoadLastScene();
            }
        }
    }
    
    public void LoadNewScene(int sceneToLoad)
    {

        currentScene = SceneManager.GetActiveScene().buildIndex;
        sceneStack.Push(currentScene);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void LoadLastScene()
    {
        lastScene = sceneStack.Pop();
        SceneManager.LoadScene(lastScene);
    }

    public static void SetLastScene(int makeCurrentSceneTheLastScene)
    {
        lastScene = makeCurrentSceneTheLastScene;
    }

    public static int GetLastScene()
    {
        return lastScene;
    }

}
