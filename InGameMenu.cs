using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public GameObject Menu;
    private bool menuOpen;
    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Menu.activeInHierarchy)
        {
            menuOpen = false;
            Time.timeScale = 1f;
        }
        else if (Menu.activeInHierarchy) 
        {
            menuOpen = true;
            Time.timeScale = 0f;
        }
        MenuEsc();
    }
    public void MenuEsc()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !menuOpen)
        {
            Menu.SetActive(true);
            
        }
        if (Input.GetKeyDown(KeyCode.Escape) && menuOpen)
        {
            Menu.SetActive(false);
        }
    }
    public void MenuClick()
    {
        Menu.SetActive(true);
        Time.timeScale = 1f;
    }
    public void ResumeClick()
    {
        Menu.SetActive(false);
    }
}