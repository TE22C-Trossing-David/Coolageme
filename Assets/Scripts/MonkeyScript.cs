using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MonkeyScript : MonoBehaviour
{

    bool monkeyPlaced = false;
    [SerializeField]
    Transform monkeyTransform;

    UnityEngine.Vector3 yCamera = new Vector3(0, 0, 10);

    List<Vector3> enemyDistnaces = new List<Vector3>();

    Vector3 currentDistance = new Vector3();
    Vector3 closestDistance = new Vector3();

    [SerializeField]
    GameObject tempmonkey;

    bool monkeynotplaced = true;

    bool enemyLocated = false;

    bool firstTime = true;

    List<Transform> enemies;

    Transform closestEnemy = null;

    bool newEnemySpawned;

    float dSqrToTarget;

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + yCamera;

        if (monkeyPlaced == false)
        {
            monkeyTransform.position = mousePos;
            if (Input.GetButton("Fire1"))
            {
                monkeyPlaced = true;
            }
        }

        if (monkeyPlaced)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy").Select(go => go.transform).ToList();

            float closestDistanceSqr = 100;
            Vector3 currentPosition = transform.position;

            foreach (Transform potentialTarget in enemies)
            {
                Vector3 directionToTarget = potentialTarget.position - currentPosition;
                dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    closestEnemy = potentialTarget;
                }

                if (directionToTarget.magnitude > closestDistanceSqr)
                {
                    transform.right = closestEnemy.position - transform.position;
                }
            }
            enemyLocated = true;
        }
    }
}
