using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoad : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject go;
    public void LoadLevel()
    {
        go = GameObject.Find("SaveManager");
        go.GetComponent<SceneStackManager>().LoadNextScene(1);
    }
    

}
