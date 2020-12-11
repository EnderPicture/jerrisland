﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class FadeImage : MonoBehaviour
{
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image.DOFade(0, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void endGame()
    {
        image.DOFade(1, 1).OnComplete(changeScene);
    }
    void changeScene()
    {
        SceneManager.LoadScene(0);
    }
}
