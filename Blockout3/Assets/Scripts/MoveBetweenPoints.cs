using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public Transform orientation;
    public Transform obj;
    
    [Header("Movement")]
    public float moveSpeed;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    
    void Move()
    {
        if (patrolPoints.Count == 0) return;
        Vector3 desPoint = patrolPoints[0].position;
        //Debug.Log(desPoint);
        orientation.forward = new Vector3(desPoint.x - orientation.position.x, 0,
            desPoint.z - orientation.position.z).normalized;
        rb.AddForce(orientation.forward * moveSpeed, ForceMode.Force);
        
        obj.forward = Vector3.Slerp(obj.forward,orientation.forward,1);
        
        // limit velocity if needed
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

        if ((patrolPoints[0].position - orientation.position).magnitude < 0.5)
        {
            var temp = patrolPoints[0];
            patrolPoints.RemoveAt(0);
            patrolPoints.Add(temp);
        }
    }
}
