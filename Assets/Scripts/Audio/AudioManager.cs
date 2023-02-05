using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private SoundEventsSO soundsEventsSO;

    private static FMOD.Studio.EventInstance musicEventInstance;

    private void Awake()
    {
        Instance = this;
        Init();
    }

    private void Init()
    {
        musicEventInstance = FMODUnity.RuntimeManager.CreateInstance(soundsEventsSO.chillMusic);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(musicEventInstance, transform);
        musicEventInstance.start();
    }

    public void ChangeMusic() => StartCoroutine(ReduceVolume());

    private IEnumerator ReduceVolume()
    {
        float reduceVolSeconds = 5f;
        float timer = reduceVolSeconds;

        while (timer >= 0.1f)
        {
            timer -= Time.deltaTime;
            musicEventInstance.setVolume(timer / reduceVolSeconds);
            yield return null;
        }

        // NOISE
        musicEventInstance.setPaused(true);
        musicEventInstance = FMODUnity.RuntimeManager.CreateInstance(soundsEventsSO.noiseMusic);
        musicEventInstance.setVolume(1);
        musicEventInstance.start();

        while (timer <= reduceVolSeconds)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        // DARK
        musicEventInstance.setPaused(true);
        musicEventInstance = FMODUnity.RuntimeManager.CreateInstance(soundsEventsSO.darkInvokeMusic);
        musicEventInstance.setVolume(0.1f);
        musicEventInstance.start();

        timer = 0.1f;
        while (timer <= reduceVolSeconds)
        {
            timer += Time.deltaTime;
            musicEventInstance.setVolume(timer / reduceVolSeconds);
            yield return null;
        }
    }

    public void SecondSection() => musicEventInstance.setParameterByName(soundsEventsSO.sectionParam, 1);
    public void ThirdSection() => musicEventInstance.setParameterByName(soundsEventsSO.sectionParam, 2);

    public void CloseInstance()
    {
        musicEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        FMODUnity.RuntimeManager.DetachInstanceFromGameObject(musicEventInstance);
    }

    #region Sounds
    public void ClickSound() => FMODUnity.RuntimeManager.PlayOneShot(soundsEventsSO.clickSound);
    public void OpenDialogSound() => FMODUnity.RuntimeManager.PlayOneShot(soundsEventsSO.openDialogSound);
    public void ChooseOptionSound() => FMODUnity.RuntimeManager.PlayOneShot(soundsEventsSO.chooseOptionSound);
    #endregion
}
