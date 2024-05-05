using UnityEngine;
using DG.Tweening;

public class ColorSpotScript : MonoBehaviour
{
    [SerializeField] private GameController.Color colorSpotColor;

    private void Start()
    {
        transform.DOScale(2.1f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) return;

        if (!(other.GetComponent<PlayerScript>().GetColor() == colorSpotColor.ToString()))
        {
            EventManager.OnGameOver();
        }
    }
}
