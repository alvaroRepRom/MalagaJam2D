using UnityEngine;

[CreateAssetMenu(fileName = "Sound Events", menuName = "Audio/Sound Events")]
public class SoundEventsSO : ScriptableObject
{
    public FMODUnity.EventReference clickSound;
    public FMODUnity.EventReference openDialogSound;
    public FMODUnity.EventReference chooseOptionSound;

    public FMODUnity.EventReference chillMusic;
    public FMODUnity.EventReference darkInvokeMusic;
    public FMODUnity.EventReference noiseMusic;

    [FMODUnity.ParamRef]
    public string changeNoiseParam;
    [FMODUnity.ParamRef]
    public string sectionParam;
}
