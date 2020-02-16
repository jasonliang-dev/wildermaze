using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public Button button;

    public static void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(RestartScene.Restart);
        button.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowButton()
    {
        button.gameObject.SetActive(true);
    }
}
