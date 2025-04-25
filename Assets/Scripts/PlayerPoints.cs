using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPoints : MonoBehaviour
{
    [SerializeField] private Text _text;
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();

    }


  private void OnTriggerEnter2D(Collider2D other)
{
    if (other.gameObject.CompareTag("Elmas"))
    {
        if (_audio != null)
        {
            _audio.Play();
        }
        else
        {
            Debug.LogError("AudioSource is null in PlayerPoints.");
        }

        Destroy(other.gameObject);
        score.totalScore++;

        if (_text != null)
        {
            _text.text = score.totalScore.ToString();
        }
        else
        {
            Debug.LogError("Text component is null in PlayerPoints.");
        }
    }
  }
}