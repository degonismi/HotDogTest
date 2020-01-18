﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GamePanel : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            EventManager.Instance.OnPlayerJumpAction?.Invoke();
        } );    
    }

}
