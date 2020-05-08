using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
       public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
        Vector3 m = new Vector3(0,400,0);
        rb.AddForce(m);
        }
        if(Input.GetKey(KeyCode.W))
        {
        Vector3 m = new Vector3(10,0,0);
        rb.AddForce(m);
        }
        if(Input.GetKey(KeyCode.S))
        {
        Vector3 m = new Vector3(-10,0,0);
        rb.AddForce(m);
        }
        if(Input.GetKey(KeyCode.A))
        {
        Vector3 m = new Vector3(0,0,10);
        rb.AddForce(m);
        }
        if(Input.GetKey(KeyCode.D))
        {
        Vector3 m = new Vector3(0,0,-10);
        rb.AddForce(m);
        }
    }
    }
     
