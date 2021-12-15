using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] Level;
    public GameObject UI;
    private void Start()
    {
        UI.SetActive(true);
        Time.timeScale = 0.00001f;
        for(int i = 0; i < Level.Length; i++)
        {
            Level[i].SetActive(false);
        }
    }
    public void StartGame()
    {
        UI.SetActive(false);
        for (int i = 0; i < Level.Length; i++)
        {
            Level[i].SetActive(true);
        }
        Time.timeScale = 1;
    }
}
