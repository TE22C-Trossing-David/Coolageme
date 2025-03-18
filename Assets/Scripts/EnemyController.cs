using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    List<Transform> points = new();
    [SerializeField] Transform enemyTransform; 
    Transform pointTransform;
    [SerializeField] float speed;
    int currentPoint = 0;
    [SerializeField] float detectionRadius = 0.01f;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject track = GameObject.Find("Track");

        for (int i = 0; i < track.transform.childCount; i++)
        {
            points.Add(track.transform.GetChild(i));
        }
        speed = 0.005f;
    }

    // Update is called once per frame
    void Update()
    {  
        
        float step = speed * Time.deltaTime;
        enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, points[currentPoint].position, speed);
        float dist = Vector3.Distance(enemyTransform.position, points[currentPoint].position);
        if (dist < detectionRadius)
        {
            currentPoint++;

        }
    }
}
