using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    [SerializeField] private SoundEventsSO soundsEventsSO;

    public void ClickSound() => FMODUnity.RuntimeManager.PlayOneShot(soundsEventsSO.clickSound);
}
