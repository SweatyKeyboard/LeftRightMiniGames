using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreCounter : MonoBehaviour
{
    [SerializeField] private Text _counter;

    private void Awake()
    {
        UpdateText();
    }
    public void UpdateText()
    {
        _counter.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
    }
}
