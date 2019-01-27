using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public GameObject menu;
    public GameObject credits;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSceneIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenCredits()
    {
        if(menu.activeSelf)
        {
            menu.SetActive(false);
            credits.SetActive(true);
        }
        else if(credits.activeSelf)
        {
            menu.SetActive(true);
            credits.SetActive(false);
        }
    }
}
