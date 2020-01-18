using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _mark;

    [SerializeField] private Color[] _blockColors;

    private bool _isActive = true;

    public float MoveSpeed {set { _moveSpeed = value; }}



    private void FixedUpdate()
    {
        if (!_isActive) return;
        if(Mathf.Abs(transform.position.x) < 8)
        {
            Move();
        }
        else
        {
            EventManager.Instance.OnBlockStopedAction?.Invoke(false);
            Debug.Log("spawn");
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_isActive)
        {
            _mark.SetActive(false);
            _moveSpeed = 0;
           
            Debug.Log("spawn for destr");
            _isActive = false;
            //Invoke(nameof(Losss), 0.1f);
            //Losss();
            StartCoroutine(seee());
        }
       
    }

    private IEnumerator seee()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this);
        Losss();
    }

    private void Losss()
    {
        EventManager.Instance.OnBlockStopedAction?.Invoke(true);
    }

    public float SetSize()
    {
        float xSize = 0, ySize = 0;

        xSize = Random.Range(1.0f, 3);
        ySize = Random.Range(0.25f, 1);

        _spriteRenderer.color = _blockColors[Random.Range(0, _blockColors.Length)];
        
        transform.localScale = new Vector3(xSize, ySize, 1);
        return ySize;
    }

    private void Move()
    {
        transform.Translate(Vector3.left * _moveSpeed / 20);
    }

}
