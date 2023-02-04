using UnityEngine;

[CreateAssetMenu(fileName = "Sound Events", menuName = "Audio/Sound Events")]
public class SoundEventsSO : ScriptableObject
{
    public FMODUnity.EventReference clickSound;
    public FMODUnity.EventReference openDialogSound;
    public FMODUnity.EventReference chooseOptionSound;
}
