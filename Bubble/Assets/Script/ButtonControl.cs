using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    [SerializeField]
    GameObject Ballons;
    [SerializeField]
    GameObject StartBtn;
    private void Update()
    {
        if (Ballons.transform.position.y == 11.8f)
        {
            StartBtn.SetActive(true);
        }
    }
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
