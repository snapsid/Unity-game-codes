using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour

{
  protected player player1;
    // Start is called before the first frame update
    void Start()
    {
        player1=GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }


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
