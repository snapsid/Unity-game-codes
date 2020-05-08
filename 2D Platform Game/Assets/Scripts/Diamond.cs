using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Diamond : MonoBehaviour
{
    public int gems=1;
    public Text gemCountText;

    private void OnTriggerEnter2D(Collider2D other)
    {
      if(other.tag=="Player")
      {
        player player1=other.GetComponent<player>();
        if(player1 != null)
        {
          player1.diamonds+=gems;
          gemCountText.text=""+player1.diamonds;
        }
        Destroy(this.gameObject);

      }
    }
}
