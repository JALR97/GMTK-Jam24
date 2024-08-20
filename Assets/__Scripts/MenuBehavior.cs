using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{
    //Components
    [SerializeField] private GameObject Credits;
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Controls;
    
    public void btnStart()
    {
        SceneManager.LoadScene(1);
    }
    public void btnCredits()
    {
        Menu.SetActive(false);
        Credits.SetActive(true);
    }
    public void btnControls()
    {
        Menu.SetActive(false);
        Controls.SetActive(true);
    }
    public void btnBack()
    {
        Menu.SetActive(true);
        Credits.SetActive(false);
        Controls.SetActive(false);
    }
    
    public void btnGameover()
    {
        Asteroid.Connections = 0;
        SceneManager.LoadScene(0);
    }
}
