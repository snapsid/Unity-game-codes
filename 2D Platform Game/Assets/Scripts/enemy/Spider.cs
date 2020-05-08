using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
  private Vector3 currentTarget;
  private SpriteRenderer sprite;

  public int Health
  {
    get; set;
  }
  public void Damage()
  {
    Debug.Log("damage");
  }


   void Start()
  {
    sprite=GetComponentInChildren<SpriteRenderer>();
  }

  public override void Update()
  {
    movement();
  }

  public void movement()
  {
    if(transform.position==a.position)
    {
      Debug.Log("a");
      sprite.flipX=false;
      //switch1= false;
      currentTarget=b.position;
      //transform.position=Vector3.MoveTowards(transform.position, b.position, speed*Time.deltaTime);
    }
    else if(transform.position==b.position)
    {
      //switch1= true;
      sprite.flipX=true;
      Debug.Log("b");
      currentTarget=a.position;
      //transform.position=Vector3.MoveTowards(transform.position, a.position, speed*Time.deltaTime);
    }
    transform.position=Vector3.MoveTowards(transform.position, currentTarget, speed*Time.deltaTime);
  }
}
