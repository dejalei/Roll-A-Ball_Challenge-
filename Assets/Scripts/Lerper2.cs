using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerper2 : MonoBehaviour
{
    Vector3 pointA = new Vector3(105, 1, 105);
     Vector3 pointB = new Vector3(105, 1, 91);
     void Update()
     {
         transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
     }
 }
