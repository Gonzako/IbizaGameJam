using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    AsyncOperation levelLoad;
    // Start is called before the first frame update
    void Start()
    {
        levelLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        levelLoad.allowSceneActivation = false;
    }

        // Update is called once per frame
        void Update()
    {
      
    }

    public void LoadNextScene()
    {
        levelLoad.allowSceneActivation = true;
    }


}
