using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class IntroGUI : MonoBehaviour
{
    public CanvasGroup canvasGroupText;


    public GameObject interactSound;





    // Start is called before the first frame update
    void Start()
    {
        canvasGroupText.DOFade(1, 1).SetDelay(2).OnStart(enableInteraction);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void enableInteraction()
    {
        canvasGroupText.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startGame()
    {
        canvasGroupText.DOFade(0, 1).OnComplete(loadGameScene);
        Instantiate(interactSound);
    }
    void loadGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
