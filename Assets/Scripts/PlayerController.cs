using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public AudioSource Coin_Audio;
    int coins = 0;
    public UnityEngine.UI.Text coinsText;
    int currentLevel = 1;
    Rigidbody rb;
    Collider coll;

    void Start()
    {

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            currentLevel = 1;
            print("Level1");
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            currentLevel = 2;
            print("Level2");
        }

        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            currentLevel = 3;
            print("Level3");
        }

        else if (SceneManager.GetActiveScene().name == "Level4")
        {
            currentLevel = 4;
            print("Level4");
        }

        rb = GetComponent<Rigidbody>();

        coll = GetComponent<Collider>();

    }

    public void Reset()
    {
        // Reset the Coins number
        coins = 0;
        // Load corresponding scene
        SceneManager.LoadScene("Level" + currentLevel);
    }

    public void NextLevel_2()
    {
        // Change the Level number
        currentLevel = 2;
        // Load corresponding scene
        SceneManager.LoadScene("Level" + currentLevel);
    }

    public void NextLevel_3()
    {
        // Change the Level number
        currentLevel = 3;
        // Load corresponding scene
        SceneManager.LoadScene("Level" + currentLevel);
    }

    public void NextLevel_4()
    {
        // Change the Level number
        currentLevel = 4;
        // Load corresponding scene
        SceneManager.LoadScene("Level" + currentLevel);
    }

    void OnTriggerEnter(Collider collider)
    {
        // Check if we ran into a coin
        if (collider.gameObject.tag == "Coin")
        {
            Coin_Audio.Play();
            coins = coins + 1;
            coinsText.text = "Coins:" + coins;
            print("Coins = " + coins);
            // Destroy coin
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.tag == "Enemy")
        {
            // Game over
            print("Game over");
            // Repeat from the current level
            Reset();
        }
        else if (collider.gameObject.tag == "Sol")
        {
            // Game over
            print("Game over");
            // Repeat from the current level
            Reset();
        }
        else if (collider.gameObject.tag == "Goal")
        {
            if (currentLevel == 1)
            {
                // Level Up
                print("Next level");
                // Go to the next level
                NextLevel_2();
            }
            else if (currentLevel == 2)
            {
                // Level Up
                print("Next level");
                // Go to the next level
                NextLevel_3();
            }
            else if (currentLevel == 3)
            {
                // Level Up
                print("Next level");
                // Go to the next level
                NextLevel_4();
            }
            else if (currentLevel == 4)
            {
                // Winner
                print("Winner");
                SceneManager.LoadScene("End");
            }
        }

    }

    // Référence à l'objet qui va disparaître
    public GameObject Cage; 

    void Update()
    {
        // Vérifie si le nombre de pièces est égal à 5
        if (coins == 5)
        {
            // Fait disparaître la Cage
            if (Cage != null)
            {
                Cage.SetActive(false);
            }
        }

    }
}

