﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    private Vector3 offset;
    void Start()
    {
        offset=transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=target.position + offset;
    }
}
