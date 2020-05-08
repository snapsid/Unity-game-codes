﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponentInChildren<Animator>();
    }

    public void Move(float move)
    {
      anim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Attack()
    {
      anim.SetTrigger("Attack");
    }
}
