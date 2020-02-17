using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public Button button;
    public Button secondary;
    public bool isActive = false;

    public static void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public static void Title()
    {
        SceneManager.LoadScene("Title");
    }

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(RestartScene.Restart);
        button.gameObject.SetActive(isActive);

        if (secondary != null)
        {
            secondary.onClick.AddListener(RestartScene.Title);
            secondary.gameObject.SetActive(isActive);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowButton()
    {
        button.gameObject.SetActive(true);

        if (secondary != null)
        {
            secondary.gameObject.SetActive(true);
        }
    }
}
