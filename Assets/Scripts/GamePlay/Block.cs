using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;


    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Stop");
    }
}
