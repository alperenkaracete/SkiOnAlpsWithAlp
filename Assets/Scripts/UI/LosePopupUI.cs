using System;
using TMPro;
using UnityEngine;

public class LosePopupUI : MonoBehaviour
{
    [SerializeField] private GameObject _losePopup;
    [SerializeField] private FallDawnDetector _fallDawnDetector;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private TextMeshProUGUI _totalSpinCounter;

    void Start()
    {
        _fallDawnDetector.PlayerFall += PlayerFall;
    }

    private void PlayerFall(float time)
    {
        Invoke("loadScene",time);
    }

    void loadScene()
    {
        _totalSpinCounter.text = _playerController._totalSpins.text;
        _losePopup.SetActive(true);
    }
}
