using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _panel;
    [SerializeField] private PlayerController _player;
    
    public void ShowCoins()
    {
        _text.text = _player.Coins.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_player.GetComponent<PlayerController>())
        {
            _panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}