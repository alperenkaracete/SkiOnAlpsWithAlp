using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinPopupUI : MonoBehaviour
{
    [SerializeField] private GameObject _winPopup;
    [SerializeField] private FinishFlag _finishFlag;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private TextMeshProUGUI _totalSpinCounter;

    void Start()
    {
        _finishFlag.PlayerFinished += PlayerFinished;
    }

    private void PlayerFinished(float time)
    {
        Invoke("loadScene",time);
    }

    void loadScene (){
        _totalSpinCounter.text = _playerController._totalSpins.text;
        _winPopup.SetActive(true);
    }
}
