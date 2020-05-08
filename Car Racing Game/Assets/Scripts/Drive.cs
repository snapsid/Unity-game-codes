using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{

  public WheelCollider[] wc;
  public float torque=200;
  public GameObject[] Wheel;
  public float maxSteerAngle=30;
  public float maxBreakTorque=500;
  public AudioSource skidSound;
  public Transform skidTrailPrefab;
  public Rigidbody rb;
  public float gearLength = 3;
  public float currentSpeed { get { return rb.velocity.magnitude * gearLength; } }

  Transform[] skidTrails=new Transform[4];

  public void StartSkidTrail(int i)
  {
    if(skidTrails[i]==null)
    {
      skidTrails[i]=Instantiate(skidTrailPrefab);
    }
    skidTrails[i].parent=wc[i].transform;
    skidTrails[i].localRotation=Quaternion.Euler(90,0,0);
    skidTrails[i].localPosition= -Vector3.up*wc[i].radius;

  }

  public void EndSkidTrail(int i)
  {
    if(skidTrails[i]==null)
    {
      return;
    }
    Transform holder =skidTrails[i];
    skidTrails[i]=null;
    holder.parent=null;
    holder.rotation=Quaternion.Euler(90,0,0);
    Destroy(holder.gameObject, 30);
  }


    // Start is called before the first frame update
    void Start()
    {
  //      wc=this.GetComponent<WheelCollider>();
    }

    public void Go(float accel, float steer, float brake)
    {
      accel=Mathf.Clamp(accel, -1, 1);
      steer=Mathf.Clamp(steer, -1, 1) * maxSteerAngle;
      brake=Mathf.Clamp(brake, 0, 1) * maxBreakTorque;

      float thrustTorque=accel*torque;

      for(int i=0; i<4; i++)
      {
      wc[i].motorTorque=thrustTorque;



      if(i<2)
      {
        wc[i].steerAngle=steer;
      }
      else{
        wc[i].brakeTorque=brake;
      }

      Quaternion quat;
      Vector3 position;

      wc[i].GetWorldPose(out position, out quat);
      Wheel[i].transform.position=position;
      Wheel[i].transform.rotation=quat;

      }
  }

    public void CheckForSkid()
    {
      int numSkidding=0;

      for(int i=0; i<4; i++)
      {
        WheelHit wheelH;
        wc[i].GetGroundHit(out wheelH);

        if(Mathf.Abs(wheelH.forwardSlip)>=0.4f || Mathf.Abs(wheelH.sidewaysSlip)>=0.4f)
        {
          numSkidding++;
          if(!skidSound.isPlaying)
          {
            skidSound.Play();
          }
          //StartSkidTrail(i);
        }
        else{
          //EndSkidTrail(i);
        }
      }

      if(numSkidding==0 && skidSound.isPlaying)
      {
        skidSound.Stop();
      }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
