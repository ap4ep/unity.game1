using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text _text;
    public GameObject Panel;

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        _text.text = _player.GetComponent<PlayerController>().CoinCount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}