using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_EndGamePanel : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Text _score;
    [SerializeField] private Text _bestScore;

    private int _scoreCount;

    private void Start()
    {
        EventManager.Instance.OnLoseAction += SetEndGameValue;
        EventManager.Instance.OnBlockStopedAction += AddScore;
        _restartButton.onClick.AddListener(Restart);

        EventManager.Instance.OnStartGameAction += () =>
        {
            _score.gameObject.SetActive(true);
        };


    }



    private void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void AddScore(bool add)
    {
        if (add)
        {
            _scoreCount++;
            _score.text = _scoreCount.ToString();
        }
    }

    private void SetEndGameValue(int score)
    {
        //gameObject.SetActive(true);
        EventManager.Instance.OnBlockStopedAction -= AddScore;
        _bestScore.gameObject.SetActive(true);
        _score.gameObject.SetActive(true);
        _restartButton.gameObject.SetActive(true);

        Debug.Log(score);
        _bestScore.text = "BEST: " + PlayerPrefs.GetInt("BestScore", 0);
        _score.text = score.ToString();
    }

}
