using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HomeUImanager : MonoBehaviour
{
    // Start the game ou charger le level 1
    public void StartGame()
    {
        SceneManager.LoadScene("level1");
    }

    // Charger le level 2
    public void Level2()
    {
        SceneManager.LoadScene("level2");
    }

    // Charger le level 3
    public void Level3()
    {
        SceneManager.LoadScene("level3");
    }

    // Charger le level 4
    public void Level4()
    {
        SceneManager.LoadScene("level4");
    }

    // Charger le menu
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Sortir de l'appli
    public void DoExitGame()
    {
        Application.Quit();
    }
}
