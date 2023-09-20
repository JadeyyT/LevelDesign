using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceBehaviour : MonoBehaviour
{
    //public Vector3 lookDir;
    public Transform orientation;
    public Vector3 lookOffset;  

    

    [Header("Looking")]     
    public float sightDistance;
    public LayerMask whatIsPlayer;
    public float radius;

    // public float xAngleDeg;
    // public float yAngleDeg;
    //
    // public float xAngleRad;
    // public float yAngleRad;

    private void Start()
    {
        // xAngleRad = (float)(xAngleDeg / 180 * Math.PI);
        // yAngleRad = (float)(yAngleDeg / 180 * Math.PI);
    }

    // Update is called once per frame
    void Update()
    {
        LookForPlayer();
        //MoveBetweenPoints();
        
    }

    private void FixedUpdate()
    {
        
    }

    // private void OnDrawGizmos()
    // {
    //     Vector3 lookDir = orientation.forward;
    //     for (int i = -10; i < 10; i++)
    //     {
    //         // Vector3 scanDir = Vector3.Normalize(
    //         //     new Vector3(lookDir.x,
    //         //     (float)(lookDir.y * Math.Cos(yAngleDeg / 180 * Math.PI * i/20) - lookDir.z * Math.Sin(yAngleDeg / 180 * Math.PI * i/20)),
    //         //     (float)(lookDir.y * Math.Sin(yAngleDeg / 180 * Math.PI * i/20) + lookDir.z * Math.Cos(yAngleDeg / 180 * Math.PI * i/20))));
    //         
    //         Vector3 yLookDir = Vector3.Normalize(
    //             new Vector3(lookDir.x,
    //                 (float)(lookDir.y * Math.Cos(yAngleDeg / 180 * Math.PI * i/20) - lookDir.z * Math.Sin(yAngleDeg / 180 * Math.PI * i/20)),
    //                 (float)(lookDir.y * Math.Sin(yAngleDeg / 180 * Math.PI * i/20) + lookDir.z * Math.Cos(yAngleDeg / 180 * Math.PI * i/20))));
    //         
    //             for (int j = -10; j < 10; j++)
    //             {
    //                 // Vector3 scanOffset = Vector3.left * j/20;
    //                 // Gizmos.color = Color.red;
    //                 // Gizmos.DrawRay(orientation.position + lookOffset +scanOffset,scanDir*sightDistance +scanOffset);
    //                 Vector3 scanDir = Vector3.Normalize(
    //                     new Vector3((float)(yLookDir.x * Math.Cos(xAngleDeg/ 180 * Math.PI * j/20) - yLookDir.z * Math.Sin(xAngleDeg/ 180 * Math.PI * j/20)),
    //                         yLookDir.y,
    //                         (float)(-1*yLookDir.x * Math.Sin(xAngleDeg/ 180 * Math.PI * j/20) + yLookDir.z * Math.Cos(xAngleDeg/ 180 * Math.PI * j/20))));
    //                 Gizmos.color = Color.red;
    //                 Gizmos.DrawRay(orientation.position + lookOffset,scanDir*sightDistance);
    //             }
    //     }
    //     
    // }

    void LookForPlayer()
    {
        //https://stackoverflow.com/questions/14607640/rotating-a-vector-in-3d-space
         
       // Vector3 lookDir = orientation.forward;
       //  for (int i = -10; i < 10; i++)
       //  {
       //      Vector3 yLookDir = Vector3.Normalize(
       //          new Vector3(lookDir.x,
       //              (float)(lookDir.y * Math.Cos(yAngleDeg / 180 * Math.PI * i/20) - lookDir.z * Math.Sin(yAngleDeg / 180 * Math.PI * i/20)),
       //              (float)(lookDir.y * Math.Sin(yAngleDeg / 180 * Math.PI * i/20) + lookDir.z * Math.Cos(yAngleDeg / 180 * Math.PI * i/20))));
       //      
       //      for (int j = -10; j < 10; j++)
       //      {
       //          Vector3 scanDir = Vector3.Normalize(
       //              new Vector3((float)(yLookDir.x * Math.Cos(xAngleDeg/ 180 * Math.PI * j/20) - yLookDir.z * Math.Sin(xAngleDeg/ 180 * Math.PI * j/20)),
       //                  yLookDir.y,
       //                  (float)(-1*yLookDir.x * Math.Sin(xAngleDeg/ 180 * Math.PI * j/20) + yLookDir.z * Math.Cos(xAngleDeg/ 180 * Math.PI * j/20))));
       //          if (Physics.Raycast(transform.position, scanDir, sightDistance, whatIsPlayer))
       //          {
       //              Debug.Log("CAUGHT");
       //          }
       //      }
       //  }
        
       RaycastHit hit;
       // Cast a sphere wrapping character controller 10 meters forward
       // to see if it is about to hit anything.
       if (Physics.SphereCast(orientation.position, radius, transform.forward, out hit, sightDistance, whatIsPlayer))
       {
           Debug.Log("CAUGHT");
       }
    }
    
}
