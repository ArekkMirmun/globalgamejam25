using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button restartButton;

    public void Start()
    {
        restartButton.Select();
    }
}
