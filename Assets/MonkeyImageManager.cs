using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class MonkeyImageManager : MonoBehaviour
{
    [SerializeField]
    public int savedNumber = 2; //mm button number

    public Button btn;

    GameObject monkeyManager;

    List<GameObject> mp;

    Image monkeyImage;
    Sprite monkeySprite;

    void Update()
    {
        monkeyManager = GameObject.Find("MonkeyManager");
        mp = monkeyManager.GetComponent<MonkeyManager>().monkeyPrefabs;
        savedNumber = GetComponentInParent<SmallMonkeyManager>().monkeyNumber;
        monkeySprite = mp[savedNumber].GetComponent<SpriteRenderer>().sprite;

        // monkeyImage = GetComponent<Image>();
        monkeyImage.image = monkeySprite.texture;
    }
}
