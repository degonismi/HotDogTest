using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Block _blockPrefab;
    [SerializeField] private float _offsetX;

    [SerializeField] private float _yPosForSpawn;
    private bool _leftSide;

    private float _offsetY;
    private bool _side;
    private float moveSpeed;


    private void Start()
    {
        _yPosForSpawn = transform.position.y;
        //SpawnBlock(false);
        EventManager.Instance.OnStartGameAction += StartSpawner;
        EventManager.Instance.OnBlockStopedAction += SpawnBlock;
        EventManager.Instance.OnLoseAction += StopSpawner;
    }

    public void StartSpawner()
    {
        SpawnBlock(false);
    }

    private void StopSpawner(int score)
    {
        EventManager.Instance.OnBlockStopedAction -= SpawnBlock;
    }

    private void SpawnBlock(bool changeSide)
    {
        Block block = Instantiate(_blockPrefab);

        if (changeSide)
        {
            _yPosForSpawn += _offsetY;
            _offsetX = -_offsetX;
        }
        else
        {
            _yPosForSpawn -= _offsetY;
        }

        _offsetY = block.SetSize() / 2;
        _yPosForSpawn += _offsetY;

        moveSpeed = Random.Range(0.8f, 1.65f);

        if (_offsetX < 0)
        {
            moveSpeed = -moveSpeed;
        }
        block.MoveSpeed = moveSpeed;

        block.transform.position = new Vector3(_offsetX, _yPosForSpawn, 0);
    }


}