using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateColorer : MonoBehaviour
{
    [SerializeField] private MeshRenderer _deck;
    [SerializeField] private MeshRenderer[] _wheels;

    private void Start()
    {

        _deck.material.color = new Color(
            Random.Range(0f, 0.2f) * 4,
            Random.Range(0f, 0.2f) * 4,
            Random.Range(0f, 0.2f) * 4);


        Color wheelColor = new Color(
            Random.Range(0f, 0.2f) * 4,
            Random.Range(0f, 0.2f) * 4,
            Random.Range(0f, 0.2f) * 4);
        foreach (MeshRenderer wheel in _wheels)
        {
            wheel.materials[0].color = wheelColor;
        }
    }
}
