using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject textInfo;

    private void Awake() 
    {
        LevelController.Instance.OnStart += HideUI;
    }

    public void HideUI()
    {
        textInfo.SetActive(false);
    }
    private void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
