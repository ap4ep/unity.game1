using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameZone : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            _panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}