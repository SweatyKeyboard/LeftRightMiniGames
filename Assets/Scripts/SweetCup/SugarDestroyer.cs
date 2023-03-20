using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarDestroyer : MonoBehaviour
{
    [SerializeField] private bool _isCatcher;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sugar"))
        {

            if (_isCatcher)
            {
                Destroy(collision.gameObject);
                _scoreCounter.AddCatch();

            }
            else
            {
                _scoreCounter.AddMiss();
                collision.gameObject.tag = "Used";
                collision.gameObject.GetComponent<RotatingObject>().enabled = false;
            }
        }

        else if (collision.gameObject.CompareTag("Coin"))
        {

            if (_isCatcher)
            {
                Destroy(collision.gameObject);
                _scoreCounter.AddCoin();
            }
            collision.gameObject.tag = "Used";
            collision.gameObject.GetComponent<RotatingObject>().enabled = false;
        }

        else if (collision.gameObject.CompareTag("Poison"))
        {
            if (_isCatcher)
            {
                Destroy(collision.gameObject);
                _scoreCounter.AddMiss();
                collision.gameObject.tag = "Used";
                collision.gameObject.GetComponent<RotatingObject>().enabled = false;
            }
            else
            {
                collision.gameObject.tag = "Used";
                collision.gameObject.GetComponent<RotatingObject>().enabled = false;
            }
        }
        else if (collision.gameObject.CompareTag("Medical"))
        {
            if (_isCatcher)
            {
                Destroy(collision.gameObject);
                _scoreCounter.Heal();
            }
        }
    }
}