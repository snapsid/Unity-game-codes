﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool canDamage=true;

    private void OnTriggerEnter2D(Collider2D other)
    {
      Debug.Log("hit by "+other.name);
      IDamageable hit= other.GetComponent<IDamageable>();

      if(hit !=null)
      {
        if(canDamage==true)
        {
            hit.Damage();
            canDamage=false;
            StartCoroutine(ResetDamage());
        }

      }
    }

    IEnumerator ResetDamage()
    {
      yield return new WaitForSeconds(0.5f);
      canDamage=true;
    }
}
