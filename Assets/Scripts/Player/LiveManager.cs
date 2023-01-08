using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LiveManager : MonoBehaviour
{
    public TextMeshProUGUI _textMeshPro;
    public PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        TextOnScreen();

        if (_playerController.health == 0) die();
    }
    void TextOnScreen()
    {
        _textMeshPro.text = "Health :" + _playerController.health + "Movement: " + _playerController.characterController.velocity;
    }
    void die()
    {
        Debug.Log("je bent dood");
        _playerController.health = 100;
    }
}
