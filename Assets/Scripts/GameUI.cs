using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Text _coinText;
    [SerializeField] private PlayerController _playerController;

    private void Start()
    {
        _playerController.OnCoinCollect += ShowCoins;
    }

    private void ShowCoins(int coins)
    {
        _coinText.text = coins.ToString();
    }
}