using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class SmallMonkeyManager : MonoBehaviour
{
    [SerializeField]
    string monkeyName;

    public int monkeyNumber; //mm button number

    public Button btn;

    GameObject monkeyManager;

    List<GameObject> mp;
    public int savedNumber;

    Vector3 yCamera = new Vector3(0, 0, 10);

    Image monkeyImage;
    Sprite monkeySprite;

    void Start()
    {
        monkeyManager = GameObject.Find("MonkeyManager");
        mp = monkeyManager.GetComponent<MonkeyManager>().monkeyPrefabs;
        savedNumber = monkeyManager.GetComponent<MonkeyManager>().savedNumber;
    }

    public void ButtonClicked()
    {
        monkeyManager.GetComponent<MonkeyManager>().savedNumber = monkeyNumber;
    }

    public void SpawnDude()
    {
        UnityEngine.Vector3 mousePos =
            Camera.main.ScreenToWorldPoint(Input.mousePosition) + yCamera;
        GameObject mnk = Instantiate(
            mp[monkeyNumber],
            mousePos,
            Quaternion.identity,
            GameObject.Find("Monkeys").transform
        );
    }
}
