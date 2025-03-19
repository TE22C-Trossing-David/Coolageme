using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MonkeyImageManager : MonoBehaviour
{
    [SerializeField]
    public int savedNumber = 2; //mm button number

    public Button btn;

    GameObject monkeyManager;

    List<GameObject> mp;

    UnityEngine.UI.Image monkeyImage;
    Sprite monkeySprite;

    void Start()
    {
        monkeyManager = GameObject.Find("MonkeyManager");
        mp = monkeyManager.GetComponent<MonkeyManager>().monkeyPrefabs;
        savedNumber = GetComponentInParent<SmallMonkeyManager>().monkeyNumber;
        monkeySprite = mp[savedNumber].GetComponent<SpriteRenderer>().sprite;

        monkeyImage = transform.GetComponent<UnityEngine.UI.Image>();
        monkeyImage.sprite = monkeySprite;

        monkeyImage.SetNativeSize();
    }
}
