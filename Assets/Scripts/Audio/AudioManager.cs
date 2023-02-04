using UnityEngine;
using FMOD;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [FMODUnity.ParamRef]
    public string changeNoiseParam;

    public SoundEventsSO soundsEventsSO;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ChangeMusic();
    }

    public void ChangeMusic()
    {
        //FMODUnity.RuntimeManager.SetParameter()
    }

    public void ClickSound() => FMODUnity.RuntimeManager.PlayOneShot(soundsEventsSO.clickSound);
    public void OpenDialogSound() => FMODUnity.RuntimeManager.PlayOneShot(soundsEventsSO.openDialogSound);
    public void ChooseOptionSound() => FMODUnity.RuntimeManager.PlayOneShot(soundsEventsSO.chooseOptionSound);
}
