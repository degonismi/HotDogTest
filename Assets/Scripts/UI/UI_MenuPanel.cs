using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MenuPanel : MonoBehaviour
{

    [SerializeField] private Button _startGameButton;
    [SerializeField] private Text _score;

    private void Start()
    {
        _score.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        _startGameButton.onClick.AddListener(() =>
        {

        });
    }

    public void StartGame()
    {

    }
}
