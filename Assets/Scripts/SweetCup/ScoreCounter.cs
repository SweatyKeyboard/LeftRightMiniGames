using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Text _catchesText;
    [SerializeField] private Text _missesText;
    [SerializeField] private Text _coinsText;

    [SerializeField] private AudioClip _catchedSound;
    [SerializeField] private AudioClip _missedSound;
    [SerializeField] private AudioClip _coinSound;

    [SerializeField] private EndGameMenu _endGameMenu;

    private int _catches;
    private int _lifes;
    private int _coins;

    private void Awake()
    {
        _lifes = 3;
        _coins = PlayerPrefs.GetInt("Coins", 0);
        _coinsText.text = "Coins: " + _coins;
    }
    private void UpdateCounters()
    {
        _catchesText.text = "Score: " + _catches;
        _missesText.text = "Lifes: " + _lifes;
        _coinsText.text = "Coins: " + _coins;
    }

    private void PlaySound(AudioClip clip, float volume = 0.1f)
    {
        PlayClipAtPoint(clip, Camera.main.transform.position, volume, Random.Range(0.9f, 1.1f));
    }

    GameObject PlayClipAtPoint(AudioClip clip, Vector3 position, float volume, float pitch)
    {
        GameObject obj = new GameObject();
        obj.transform.position = position;
        AudioSource audio = obj.AddComponent<AudioSource>();
        audio.pitch = pitch;
        audio.PlayOneShot(clip, volume);
        Destroy(obj, clip.length / pitch);
        return obj;
    }

    public void AddCatch()
    {
        _catches++;
        UpdateCounters();
        PlaySound(_catchedSound);
    }

    public void Heal()
    {
        _lifes++;
        UpdateCounters();
        PlaySound(_catchedSound);
    }

    public void AddCoin()
    {
        _coins++;
        UpdateCounters();
        PlaySound(_coinSound, 0.5f);
    }

    public void AddMiss()
    {
        _lifes--;
        UpdateCounters();
        PlaySound(_missedSound);

        if (_lifes <= 0)
        {
            _endGameMenu.Activate(_catches);
            PlayerPrefs.SetInt("Coins", _coins);
        }
    }


}
