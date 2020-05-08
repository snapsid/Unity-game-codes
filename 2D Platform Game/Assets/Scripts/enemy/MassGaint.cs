using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassGaint : Enemy, IDamageable
{

    private bool switch1=false;
    private Vector3 currentTarget;
    private SpriteRenderer sprite;
    protected Animator anim;
    protected bool isHit=false;
    protected player player1;


    public int Health
    {
      get; set;
    }
    public void Damage()
    {
      Debug.Log("damage");
      health--;
      anim.SetTrigger("Hit");
      isHit=true;
      anim.SetBool("Attack", true);

      if(health<1)
      {
        Destroy(this.gameObject);
      }
    }


     void Start()
    { //Debug.Log("health"+health);
      anim=GetComponentInChildren<Animator>();
      sprite=GetComponentInChildren<SpriteRenderer>();
      Health=base.health;
      player1=GameObject.FindGameObjectWithTag("Player").GetComponent<player>();

      //Attack();
    }

    public override void Attack()
    {

    }

    public override void Update()
    {
      movement();
    }
    public void movement()
    {
      if(transform.position==a.position)
      {
        //Debug.Log("a");
        sprite.flipX=false;
        switch1= false;
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


      // if(isHit==false)
      // {
      transform.position=Vector3.MoveTowards(transform.position, currentTarget, speed*Time.deltaTime);
    //  }

        float distance=Vector3.Distance(transform.position, player1.transform.position);
        if(distance>4.0f)
        {
          isHit=false;
          anim.SetBool("Attack", false);
        }

        Vector3 direction=player1.transform.localPosition-transform.localPosition;
        if(direction.x>0 && anim.GetBool("Attack")==true)
        {
          sprite.flipX=false;
        }
        else if(direction.x< 0 && anim.GetBool("Attack")==true)
        {
          sprite.flipX=true;
        }

    }
}
