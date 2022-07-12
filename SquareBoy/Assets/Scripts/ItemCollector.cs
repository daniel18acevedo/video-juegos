using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [Header("For collecting item")]
    [SerializeField] private TextMeshProUGUI _melonsText;
    [SerializeField] private AudioSource _collectionSoundEffect;
    private int _melons = 0;
    public static int Melons { get; private set; }

    public void Start()
    {
        Melons = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Melon"))
        {
            Destroy(collision.gameObject);
            this._melons++;
            this._melonsText.text = $"{this._melons}";
            this._collectionSoundEffect.Play();
            Melons = this._melons;
        }
    }
}
