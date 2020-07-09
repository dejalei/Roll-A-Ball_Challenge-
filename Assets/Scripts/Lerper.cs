using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerper : MonoBehaviour
{
   Vector3 pointA = new Vector3(92, 1, 107);
     Vector3 pointB = new Vector3(108, 1, 107);
     void Update()
     {
         transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
     }
 }