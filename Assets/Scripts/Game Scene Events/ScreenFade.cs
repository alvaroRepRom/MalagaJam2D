using UnityEngine;
using DG.Tweening;

public class ScreenFade : MonoBehaviour
{
    public bool isFinalScene;
    public float fadeSeconds = 3f;

    private SpriteRenderer fondo;

    private void Awake() => fondo = GetComponent<SpriteRenderer>();
    private void Start()
    {
        if (isFinalScene) FadeOut();
        else GameManager.Instance.onTimeComplete += FadeIn;
    }
    private void OnDisable() => GameManager.Instance.onTimeComplete -= FadeIn;
    private void FadeOut()
    {
        Color newColor = new(fondo.color.r, fondo.color.r, fondo.color.r, 0);
        fondo.DOColor(newColor, fadeSeconds).SetEase(Ease.InSine).Play();
    }

    private void FadeIn()
    {
        Color newColor = new(fondo.color.r, fondo.color.r, fondo.color.r, 1);
        fondo.DOColor(newColor, fadeSeconds).SetEase(Ease.InSine).Play();
    }
}
