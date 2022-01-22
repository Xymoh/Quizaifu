using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairManager : MonoBehaviour
{
    [SerializeField] private GameObject[] chairModels;
    private int currentChair;
    // Start is called before the first frame update
    void Start()
    {
        currentChair = SaveManager.instance.currentChair;
       
        ChooseChair(currentChair);
    }

    // Update is called once per frame
    void ChooseChair(int _index)
    {
        chairModels[_index].SetActive(true);
    }
}
