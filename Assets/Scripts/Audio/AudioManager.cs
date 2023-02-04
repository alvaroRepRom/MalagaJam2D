using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public FMODUnity.EventReference chill;

    [FMODUnity.ParamRef]
    public string changeNoiseParam;

    public SoundEventsSO soundsEventsSO;

    public FMODUnity.StudioEventEmitter musicEmitter;
    public FMODUnity.StudioEventEmitter darkMusicEmitter;

    private FMOD.Studio.EventInstance musicEventInstance;

    private void Awake()
    {
        Instance = this;
        musicEventInstance = FMODUnity.RuntimeManager.CreateInstance(chill);
        musicEventInstance.start();
        musicEventInstance.release();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ChangeMusic();
    }

    public void ChangeMusic()
    {
        musicEventInstance.setPaused(true);
        //musicEventInstance.release();
        musicEventInstance = FMODUnity.RuntimeManager.CreateInstance(soundsEventsSO.darkInvokeMusic);
        musicEventInstance.start();
    }

    public void ClickSound() => FMODUnity.RuntimeManager.PlayOneShot(soundsEventsSO.clickSound);
    public void OpenDialogSound() => FMODUnity.RuntimeManager.PlayOneShot(soundsEventsSO.openDialogSound);
    public void ChooseOptionSound() => FMODUnity.RuntimeManager.PlayOneShot(soundsEventsSO.chooseOptionSound);
}
