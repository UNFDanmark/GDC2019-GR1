using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameScene : MonoBehaviour
{
    public void BeginGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
