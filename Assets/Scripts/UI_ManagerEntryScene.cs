using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_ManagerEntryScene : MonoBehaviour
{
    public Animator camAnimation;
    public GameObject UIpanel;

    void Start()
    {
        if(PlayerPrefs.GetInt("Level") == 0)
            PlayerPrefs.SetInt("Level",1);
        else if (PlayerPrefs.GetInt("Level") > SceneManager.sceneCount)
        {
            PlayerPrefs.SetInt("Level",1);
            Debug.LogError("!!! ALL LEVELS ARE PLAYED, SO LEVEL IS RESET TO LEVEL-1  !!!");
        }

    }

    private void Update()
    {
        if (camAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.25f)
            UIpanel.SetActive(true);
    }

    public void StartFromLastLevel()
    {
        int levelNum = PlayerPrefs.GetInt("Level");
        if (levelNum < SceneManager.sceneCount + 1)
            SceneManager.LoadScene(levelNum);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

}
