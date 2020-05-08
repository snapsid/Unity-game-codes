using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

  public Circuit circuit;
  Drive ds;
  public float stearingSensitivity=0.1f;

  Vector3 target;
  int currentWP=0;

    // Start is called before the first frame update
    void Start()
    {
        ds=this.GetComponent<Drive>();
        target=circuit.wayPoints[currentWP].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 localTarget=ds.rb.gameObject.transform.InverseTransformPoint(target);
        float distanceToTarget=Vector3.Distance(target, ds.rb.gameObject.transform.position);
        //
        float targetAngle =Mathf.Atan2(localTarget.x, localTarget.z)*Mathf.Rad2Deg;
        //
        float steer= Mathf.Clamp(targetAngle*stearingSensitivity, -1, 1)*Mathf.Sign(ds.currentSpeed);

        float accel=0.5f;
        float brake=0;




        if(distanceToTarget<5)
        {
          // accel=0.5f;
          // brake=0.5f;

        }

        ds.Go(accel, steer, brake);
        if(distanceToTarget<3)
        {
          currentWP++;
          if(currentWP >= circuit.wayPoints.Length)
          {
            currentWP=0;
          }
          target=circuit.wayPoints[currentWP].transform.position;
        }


        ds.CheckForSkid();

    }
}
