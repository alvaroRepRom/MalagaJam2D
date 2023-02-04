using UnityEngine;
using DG.Tweening;

public class BirthCartel : MonoBehaviour
{
    public float endDistance = 1;
    public float secondsFalling = 1;

    private void Start()
    {
        GameManager.Instance.onTimeComplete += Fall;
        //Fall();
    }

    private void OnDisable() => GameManager.Instance.onTimeComplete -= Fall;

    private void Fall()
    {
        Sequence fallSequence = DOTween.Sequence();
        float endPos = transform.position.y - endDistance;
        //fallSequence.Append(t).SetLoops(-1, LoopType.Yoyo);
        fallSequence.Append(transform.DOMoveY(endPos, secondsFalling));
        fallSequence.Play();
    }
}
