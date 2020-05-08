using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour, IDamageable
{
    public Rigidbody2D rigid;
    [SerializeField]
    public float jumpForce=5.0f;
    [SerializeField]
    public bool grounded=false;
    public bool resetJumpNeeded = false;
    [SerializeField]
    private float speed=5.0f;

    private PlayerAnimation anim;
    private SpriteRenderer sprite;

    public int Health{get; set;}
    public int hea;

    public Image hea1,hea2,hea3,hea4;

    public int diamonds;
    protected Animator anim1;
    public int deathCheck=0;

    // Start is called before the first frame update
    void Start()
    {
        rigid=GetComponent<Rigidbody2D>();
        anim=GetComponent<PlayerAnimation>();
        sprite=GetComponentInChildren<SpriteRenderer>();

        anim1=GetComponentInChildren<Animator>();
        //Health=4;
        hea=4;
    }

    // Update is called once per frame
    void Update()
    {
        if(deathCheck==0)
        {
          movement();
          if(Input.GetKeyDown(KeyCode.L))
          {
            anim.Attack();
          }
        }
        if(hea==4)
        {
          hea4.gameObject.SetActive(true);
          //Destroy(hea4.gameObject);
        }
        if(hea==3)
        {
          hea3.gameObject.SetActive(true);
        }
        if(hea==2)
        {
          hea2.gameObject.SetActive(true);
        }

    }

      void movement()
      {
        float move=Input.GetAxisRaw("Horizontal");
        flip(move);


        if(Input.GetKeyDown(KeyCode.Space) && grounded==true)
        {
          rigid.velocity=new Vector2(rigid.velocity.x, jumpForce);
          grounded=false;
          resetJumpNeeded=true;
          StartCoroutine(ResetJumpNeededRoutien());
        }

        RaycastHit2D hitInfo=Physics2D.Raycast(transform.position, Vector2.down, 0.6f, 1 << 8);

        if(hitInfo.collider !=null)
        {
          if(resetJumpNeeded==false)
          grounded=true;
        }

        rigid.velocity=new Vector2(move*speed, rigid.velocity.y);
        anim.Move(move);
      }
      void flip(float move)
      {
        if(move>0)
        {
          sprite.flipX=false;
        }
        if(move<0)
        {
          sprite.flipX=true;
        }
      }

    public IEnumerator ResetJumpNeededRoutien()
    {
      yield return new WaitForSeconds(0.1f);
      resetJumpNeeded=false;
    }

    public void Damage()
    {
      Debug.Log("Player Damage()");

      hea=hea-1;
      if(hea==3)
      {
      //  Destroy(hea4.gameObject);
      hea4.gameObject.SetActive(false);
      }
      if(hea==2)
      {
        //Destroy(hea3.gameObject);
        hea3.gameObject.SetActive(false);
      }
      if(hea==1)
      {
        //Destroy(hea2.gameObject);
        hea2.gameObject.SetActive(false);
      }
      if(hea==0)
      {
        hea1.gameObject.SetActive(false);
        anim1.SetTrigger("Death");
        deathCheck=1;
        //Destroy(this.gameObject);
      }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
      Debug.Log("trigger");
      if(other.tag=="Obstacle")
      {
        Debug.Log("obstacle");

      //if(hea4.gameObject!)
      anim1.SetTrigger("Death");
      deathCheck=1;
        // Destroy(hea4.gameObject);
        // Destroy(hea3.gameObject);
        // Destroy(hea2.gameObject);
        // Destroy(hea1.gameObject);
        hea=0;
        hea4.gameObject.SetActive(false);
        hea3.gameObject.SetActive(false);
        hea2.gameObject.SetActive(false);
        hea1.gameObject.SetActive(false);


        //Destroy(this.gameObject);
      }
    }
}
