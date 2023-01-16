using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LiveManager : MonoBehaviour
{
  
    public PlayerController _playerController;
    private string Protected;
    public bool died;

    // Start is called before the first frame update
    void Start()
    {
        died = false;
        _playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
    

        if (_playerController.health == 0)  died = true; 

        if (_playerController.safe)
        {
            Protected = "Protected";
        }else { Protected = "Not Protected";}
    }
   
    void die()
    {
        Debug.Log("je bent dood");
        _playerController.health = 100;
    }
}
