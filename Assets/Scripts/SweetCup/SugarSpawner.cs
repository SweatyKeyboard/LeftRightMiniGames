using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarSpawner : MonoBehaviour
{
    [SerializeField] private Transform _sugarPrefab;
    [SerializeField] private Transform _coinPrefab;

    private float _lastSpawnedTime = 0f;
    private float _randomDelay = 0f;

    private bool _isCoin = false;

    private void Update()
    {
        if (!EndGameMenu.IsGamePaused)
        {
            if (Time.timeSinceLevelLoad > _lastSpawnedTime + _randomDelay)
            {
                _randomDelay = Random.Range(0.8f, 1.5f) - Time.timeSinceLevelLoad / 500;
                _lastSpawnedTime = Time.timeSinceLevelLoad;

                Transform prefab = _sugarPrefab;
                
                if (Random.Range(0,100) < 5)
                {
                    prefab = _coinPrefab;
                    _isCoin = true;
                }
                else
                {
                    _isCoin = false;
                }

                Transform spawned = Instantiate(
                    prefab,
                    new Vector3(
                        Random.Range(-1.5f, 1.5f),
                        9,
                        Random.Range(0.8f, 1.2f)),
                    new Quaternion(
                        Random.Range(0, 360),
                        Random.Range(0, 360),
                        Random.Range(0, 360),
                        0));

                if (Random.Range(0, 100) < 10 && !_isCoin)
                {
                    MakePoisonous(ref spawned);
                }
                else if(Random.Range(0, 100) < 2 && !_isCoin)
                {
                    MakeMedical(ref spawned);
                }
            }
        }
    }

    private void MakePoisonous(ref Transform target)
    {
        target.tag = "Poison";

        MarkedObject markedObject = target.gameObject.AddComponent<MarkedObject>();
        markedObject.Color = new Color(0.1f, 0.9f, 0.05f);
        markedObject.OutlineWidth = 5f;
        markedObject.TrailWidth = 0.1f;
        markedObject.Initialize();
    }

    private void MakeMedical(ref Transform target)
    {
        target.tag = "Medical";

        MarkedObject markedObject = target.gameObject.AddComponent<MarkedObject>();
        markedObject.Color = new Color(0.95f, 0.1f, 0.4f);
        markedObject.OutlineWidth = 5f;
        markedObject.TrailWidth = 0.1f;
        markedObject.Initialize();
    }
}
