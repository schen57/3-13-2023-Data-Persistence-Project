using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public static MenuUIHandler Instance;
    public string playerName;
    public TMP_InputField nameInput;
    

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void NewPlayerName(string name)
    {
        MenuUIHandler.Instance.playerName = name;
    }


    public void StartNew()
    {
        NewPlayerName(nameInput.text); // set playerName with the text from the input field
        Debug.Log("Player name: " + nameInput.text); // log the player name to the console for debugging purposes
        SceneManager.LoadScene(0);


    }

    public void Quit()
    {
        if (Application.isEditor && EditorApplication.isPlaying)
        {

            EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit();
        }
    }


}

//Open issue. It seems that if I were to go back to the mainmenu for the second time and try and change the player name the start doesn;t work anymore