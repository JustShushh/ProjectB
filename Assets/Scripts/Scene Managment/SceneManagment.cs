using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SwitchToScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
    
    public IEnumerator LoadLevel(string name)
    {
        // fade out
        yield return new WaitForSeconds(0.01f);
        SwitchToScene(name);
    }
}
