using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchTrigger : MonoBehaviour
{
    [SerializeField] SceneManagment sceneManagement;
    [SerializeField] string sceneName;
    // Start is called before the first frame update
    void Start()
    {
     sceneManagement = Instantiate<SceneManagment>(sceneManagement);   
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(sceneManagement.LoadLevel(sceneName));
    }
}
