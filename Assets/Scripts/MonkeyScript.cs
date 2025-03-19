using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MonkeyScript : MonoBehaviour
{
    //Monkey Stats
    [SerializeField]
    float atkSpeed = 1;

    [SerializeField]
    float range = 3;

    [SerializeField]
    int cost = 100;

    bool monkeyPlaced = false;

    [SerializeField]
    Transform monkeyTransform;

    UnityEngine.Vector3 yCamera = new Vector3(0, 0, 10);

    bool enemyLocated = false;

    List<Transform> enemies;

    float distanceToCurrentClosest;

    Transform closestEnemy = null;

    Transform rangeCircle;

    void Start()
    {
        distanceToCurrentClosest = range;
    }

    void Update()
    {
        UnityEngine.Vector3 mousePos =
            Camera.main.ScreenToWorldPoint(Input.mousePosition) + yCamera;

        if (monkeyPlaced == false)
        {
            monkeyTransform.position = mousePos;
            if (Input.GetButton("Fire1"))
            {
                monkeyPlaced = true;
            }
            transform.GetChild(0).gameObject.SetActive(true);
        }

        if (monkeyPlaced)
        {
            transform.GetChild(0).gameObject.SetActive(false);

            Vector3 monkeyPosition = transform.position;
            enemies = GameObject
                .FindGameObjectsWithTag("Enemy")
                .Select(go => go.transform)
                .ToList();
            if (!enemyLocated)
                closestEnemy = enemies[0];

            foreach (Transform potentialTarget in enemies)
            {
                float distanceToTarget = Vector3.Distance(potentialTarget.position, monkeyPosition);

                if (distanceToTarget < distanceToCurrentClosest)
                {
                    closestEnemy = potentialTarget;
                }

                distanceToCurrentClosest = Vector3.Distance(closestEnemy.position, monkeyPosition);

                if (range >= distanceToCurrentClosest)
                {
                    transform.right = closestEnemy.position - transform.position;
                }
            }
            enemyLocated = true;
        }
    }

    public void OpenInfo()
    {
        Debug.Log("yaho");
    }
}
