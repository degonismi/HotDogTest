using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESY : MonoBehaviour
{

    [SerializeField] private GameObject _ttt;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(_ttt);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Destroy(_ttt);
        }

    }
}
