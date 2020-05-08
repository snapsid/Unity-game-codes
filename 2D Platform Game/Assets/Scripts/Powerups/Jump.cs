using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
  public float jump=5.7f;
  private void OnTriggerEnter2D(Collider2D other)
  {
    if(other.tag=="Player")
    {
      player player1=other.GetComponent<player>();

      Destroy(this.gameObject);
      player1.jumpForce=jump;

    }
  }
}
