using UnityEngine;

public class TableDisapear : MonoBehaviour
{
    public GameObject table;
    public ParticleSystem explosion;

    private void Start() => GameManager.Instance.onTimeComplete += Explosion;
    private void OnDisable() => GameManager.Instance.onTimeComplete -= Explosion;

    private void Explosion()
    {
        explosion.Play();
        table.SetActive(false);
    }
}
