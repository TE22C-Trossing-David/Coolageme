using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SmallMonkeyManager : MonoBehaviour
{
    [SerializeField]
    string monkeyName;

    public int monkeyNumber; //mm button number

    GameObject monkeyManager;
    public Button btn;



    void Start()
    {
        // btn.onClick.AddListener(ButtonClicked);


    }


    public void ButtonClicked()
    {
        monkeyManager = GameObject.Find("MonkeyManager");
        monkeyManager.GetComponent<MonkeyManager>().savedNumber = monkeyNumber;
        print(monkeyManager.GetComponent<MonkeyManager>().savedNumber);
    }
}
