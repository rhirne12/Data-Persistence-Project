using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenuUIHandler : MonoBehaviour
{
    private new GameObject name;
    private GameObject nameHigh;

    // Start is called before the first frame update
    void Start()
    {
        //  Grabs the name from the Input Field of the game object
        name = GameObject.Find("Name input");
        GameManager.Instance.LoadBestScore();
        if (GameManager.Instance.highScore != 0)
        {
            nameHigh = GameObject.Find("High Score");
            nameHigh.GetComponent<TMP_Text>().text = "Best Score: " + GameManager.Instance.playerHighScore + " : " + GameManager.Instance.highScore;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void StartClick()
    {
        GameManager.Instance.player = name.GetComponent<TMP_InputField>().text;
        SceneManager.LoadScene(1);
    }

    public void ExitClicked()
    {
#if UNITY_EDITOR 
        EditorApplication.ExitPlaymode();  // If still in playmode in unity editor
#else
        Application.Quit();  // Standard Exit application 
#endif
    }
}
