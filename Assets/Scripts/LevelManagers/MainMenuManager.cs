using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    #region Variables
    public GameObject panel;
    #endregion
    public void LoadLevel(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Salio del juego");
    }
}
