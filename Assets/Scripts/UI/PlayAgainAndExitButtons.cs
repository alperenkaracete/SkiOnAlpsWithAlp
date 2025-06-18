using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayAgainAndExitButtons : MonoBehaviour
{
    [SerializeField] private Button _playAgainButton;
    [SerializeField] private Button _exitButton;

    void Start()
    {
        _playAgainButton.onClick.AddListener(PlayAgain);
        _exitButton.onClick.AddListener(Exit);

    }

    private void Exit()
    {
        Application.Quit();
    }

    private void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
