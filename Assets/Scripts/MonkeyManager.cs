using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class MonkeyManager : MonoBehaviour
{

    public List<GameObject> monkeyPrefabs = new List<GameObject>();

    Vector2 ButtonPosition = new Vector2(-840, 400);

    [SerializeField]
    GameObject ButtonPrefab;

    [SerializeField]
    GameObject Canvas;

    public int savedNumber;



    void Start()
    {
        int buttonNumber = 0;

        for (int i = 0; i < monkeyPrefabs.Count / 2; i++)
        {
            for (int o = 0; o < 2; o++)
            {
                ButtonPosition.x += o * 200;
                GameObject btn = Instantiate(ButtonPrefab, ButtonPosition, Quaternion.identity);
                btn.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
                btn.GetComponent<SmallMonkeyManager>().monkeyNumber = buttonNumber;
                buttonNumber++;
            }
            ButtonPosition.x -= 200;
            ButtonPosition.y -= 200;
        }

        GameObject cool = monkeyPrefabs[1];
    }

    void Update()
    {


    }


}
