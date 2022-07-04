using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int _melons = 0;
    [SerializeField] private TextMeshProUGUI _melonsText;
    [SerializeField] private AudioSource _collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Melon"))
        {
            Destroy(collision.gameObject);
            this._melons++;
            this._melonsText.text = $"Melons: {this._melons}";
            this._collectionSoundEffect.Play();
        }
    }
}
