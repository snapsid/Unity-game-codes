using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
  
  private void OnTriggerEnter2D(Collider2D other)
  {
    if(other.tag=="Player")
    {
      player player1=other.GetComponent<player>();


        Destroy(this.gameObject);
        SceneManager.LoadScene("level2");
    }
  }
}
