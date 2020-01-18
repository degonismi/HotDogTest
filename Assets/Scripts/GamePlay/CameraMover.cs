using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void LateUpdate()
    {
        if (!_player) return;
        if(transform.position.y < (_player.transform.position. y - 1f))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, _player.transform.position.y, -10), 10 * Time.deltaTime);
            //transform.Translate(Vector3.up);
        }
    }

}
