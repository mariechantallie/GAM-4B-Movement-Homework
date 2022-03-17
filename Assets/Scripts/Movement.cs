using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
   const float RayDistance = 2f;
   [SerializeField]KeyCode forward,left, backwards, right;
   [SerializeField]KeyCode jump = KeyCode.Space;
   [SerializeField]float moveSpeed = 500f;
   [SerializeField]float jumpForce = 1000f;
   float groundCheckDist = 1.05f;
   Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        HandleInput();
        CheckRays();
               
    }

     void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position,transform.position + (transform.forward * RayDistance));
        Gizmos.DrawSphere(transform.position + (transform.forward * RayDistance),.1f);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position,transform.position - (Vector3.up* (groundCheckDist)));
        Gizmos.DrawSphere(transform.position - (Vector3.up* (groundCheckDist)),.1f);
        
    }

    void CheckRays()
    {
        if (Physics.Raycast(transform.position,transform.forward, out RaycastHit hit,RayDistance))
        {
            Debug.Log(hit.collider.gameObject.name);
        }
                            
    }   

    void HandleInput()
    {
         if(Input.GetKey(forward))
        {                            
            rb.AddForce(transform.forward * moveSpeed * Time.deltaTime);
        }       
        if(Input.GetKey(backwards))
        {                            
            rb.AddForce(-transform.forward * moveSpeed * Time.deltaTime);
        }     
        if(Input.GetKey(left))
        {                            
            rb.AddForce(-transform.right * moveSpeed * Time.deltaTime);
        }     
        if(Input.GetKey(right))
        {                            
            rb.AddForce(transform.right * moveSpeed * Time.deltaTime);
        }     
        if(Input.GetKeyDown(jump))
        {                            
            if(Physics.Raycast(transform.position,Vector3.down,groundCheckDist))
            {
                
                 rb.AddForce(Vector3.up * moveSpeed);
            }
           

        }     
    }
    
    


}
