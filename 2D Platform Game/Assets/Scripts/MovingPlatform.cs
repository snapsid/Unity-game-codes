using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : player
{
  [SerializeField]
  protected Transform a,b;
  [SerializeField]
  protected int speed1;
  protected player player1;

  private Vector3 currentTarget;
  private Vector3 abc;
    // Start is called before the first frame update
    void Start()
    {
      player1=GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
      //rigid=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

      if(transform.position==a.position)
      {
        //Debug.Log("a");
      //  sprite.flipX=false;
        //switch1= false;
        currentTarget=b.position;
        //transform.position=Vector3.MoveTowards(transform.position, b.position, speed*Time.deltaTime);
      }
      else if(transform.position==b.position)
      {
        //switch1= true;
        //sprite.flipX=true;
        Debug.Log("b");
        currentTarget=a.position;
        //transform.position=Vector3.MoveTowards(transform.position, a.position, speed*Time.deltaTime);
      }


      // if(isHit==false)
      // {
      transform.position=Vector3.MoveTowards(transform.position, currentTarget, speed1*Time.deltaTime);
      abc=transform.position;
    }
    //  void OnCollisionEnter2D(Collision2D other)
    // {
    //   if(other.tag=="Player")
    //   {
    //     // Debug.Log("hi");
    //     // player player1=other.GetComponent<player>();
    //     // player1.grounded=true;
    //     Destroy(this.gameObject);
    //   }
    // }
    void OnCollisionStay2D(Collision2D coll) {
      // if(coll.tag=="Player")
      // {
      //   // Debug.Log("hi");
      //   // player player1=other.GetComponent<player>();
       player1.grounded=true;


      // player1.transform.position=abc;
         //Destroy(this.gameObject);
      // }


    }
    void OnCollisionExit2D(Collision2D other)
    {
        player1.grounded=false;
    }
}
