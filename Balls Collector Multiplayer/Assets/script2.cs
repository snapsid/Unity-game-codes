using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script2 : MonoBehaviour
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
        if(Input.GetKeyDown(KeyCode.L))
        {
        Vector3 m = new Vector3(0,400,0);
        rb.AddForce(m);
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
        Vector3 m = new Vector3(10,0,0);
        rb.AddForce(m);
        }
        if(Input.GetKey (KeyCode.DownArrow))
        {
        Vector3 m = new Vector3(-10,0,0);
        rb.AddForce(m);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
        Vector3 m = new Vector3(0,0,10);
        rb.AddForce(m);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
        Vector3 m = new Vector3(0,0,-10);
        rb.AddForce(m);
        }
    }
    }

