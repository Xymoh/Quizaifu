using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    private GameObject SceneSaveManager;
    void Awake()
    {
        SceneSaveManager = GameObject.Find("SaveManager");
    }
   
    public void LoadLastScene()
    {
        Time.timeScale = 1;
        SceneSaveManager.GetComponent<SceneStackManager>().LoadLastScene();

    }

    public void LoadChairMenu()
    {
        Time.timeScale = 1;
        LoadLevel(SceneSaveManager, 4);
    }

    public void LoadLevel(GameObject _go, int _sceneNumber)
    {
        _go.GetComponent<SceneStackManager>().LoadNextScene(_sceneNumber);

    }
}
