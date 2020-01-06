using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    Scene CurrentScene;
    [SerializeField]
    GameObject Restart;

    // Start is called before the first frame update
    void Start()
    {
        CurrentScene = SceneManager.GetActiveScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(CurrentScene.buildIndex + 1);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Restart.activeSelf == true)
            {
                SceneManager.LoadScene(CurrentScene.buildIndex);
                Time.timeScale = 1f;
            }
            
        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && CurrentScene.buildIndex != 0)
        {
            LoadNextScene();
        }
    }
}
