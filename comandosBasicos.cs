using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class comandosBasicos : MonoBehaviour
{
    public void carregaCena (string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    public void QuitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;

        Application.Quit();

    }
}
