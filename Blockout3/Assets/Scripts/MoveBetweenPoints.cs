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
        //rb.drag = 5;
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
        
        orientation.forward = new Vector3(desPoint.x - orientation.position.x, 0,
                            desPoint.z - orientation.position.z).normalized;
        
        rb.AddForce(orientation.forward * (moveSpeed * 10f), ForceMode.Force);
        
        obj.forward = Vector3.Slerp(orientation.forward,obj.forward,0.5f);
        
        // limit velocity if needed
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (new Vector2(patrolPoints[0].position.x - orientation.position.x,patrolPoints[0].position.z - orientation.position.z).magnitude < 5f ||
            new Vector2(patrolPoints[^1].position.x - orientation.position.x,patrolPoints[^1].position.z - orientation.position.z).magnitude < 5f)
        {
            Vector3 limitedVel = flatVel.normalized * 10;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
        else
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

        if (new Vector2(patrolPoints[0].position.x - orientation.position.x,patrolPoints[0].position.z - orientation.position.z).magnitude < 0.5f)
        {
            var temp = patrolPoints[0];
            patrolPoints.RemoveAt(0);
            patrolPoints.Add(temp);
        }
    }
}
