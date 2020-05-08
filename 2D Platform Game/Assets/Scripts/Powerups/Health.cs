using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D other)
  {
    if(other.tag=="Player")
    {
      player player1=other.GetComponent<player>();

      Destroy(this.gameObject);
      if(player1.hea!=4)
      {
      player1.hea=player1.hea+1;
      }
    }
  }
}
