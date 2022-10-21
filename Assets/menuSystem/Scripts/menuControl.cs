using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour
{
    [SerializeField]
    string playScene;

    public void StartGame()
    {
        SceneManager.LoadScene(playScene);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        SceneManager.LoadScene("Quit");
    }

}
