using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpScript : MonoBehaviour
{
    [SerializeField]
    TMP_Text hpText;
    public int currentHp = 140;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        hpText.text = currentHp.ToString();
    }
}
