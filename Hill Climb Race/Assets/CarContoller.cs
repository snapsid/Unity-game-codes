using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarContoller : MonoBehaviour
{

public Rigidbody2D carRigidbody;
public Rigidbody2D backTire;
public Rigidbody2D frontTire;

public float fuel=1;
public float fuelConsimption =0.1f;
private float movement;
private float jump;
public float speed=10;
public float carTorque=10;
public UnityEngine.UI.Image image;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        movement=Input.GetAxis("Horizontal");

        image.fillAmount=fuel;

        if(Input.GetKeyDown(KeyCode.L))
        {
        Vector3 m = new Vector3(0,400,0);
        carRigidbody.AddForce(m);
        }
    }
    private void FixedUpdate()
    {
      if(fuel>0)
      {
      backTire.AddTorque( -movement*speed*Time.fixedDeltaTime);
      frontTire.AddTorque( -movement*speed*Time.fixedDeltaTime);
      carRigidbody.AddTorque(-movement*carTorque*Time.fixedDeltaTime);

      }

      fuel-=fuelConsimption * Mathf.Abs(movement)* Time.fixedDeltaTime;
    }
}
