using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public SoundEventsSO soundsEventsSO;

    private static FMOD.Studio.EventInstance musicEventInstance;

    private void Awake()
    {
        Instance = this;
        Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ChangeMusic();
    }

    private void Init()
    {
        musicEventInstance = FMODUnity.RuntimeManager.CreateInstance(soundsEventsSO.chillMusic);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(musicEventInstance, transform);
        musicEventInstance.start();
        //musicEventInstance.release();
    }

    public void ChangeMusic()
    {
        StartCoroutine(ReduceVolume());
    }

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

        musicEventInstance.setPaused(true);
        musicEventInstance = FMODUnity.RuntimeManager.CreateInstance(soundsEventsSO.darkInvokeMusic);
        musicEventInstance.start();

        while (timer <= reduceVolSeconds)
        {
            timer += Time.deltaTime;
            musicEventInstance.setVolume(timer / reduceVolSeconds);
            yield return null;
        }
    }

    #region Sounds
    public void ClickSound() => FMODUnity.RuntimeManager.PlayOneShot(soundsEventsSO.clickSound);
    public void OpenDialogSound() => FMODUnity.RuntimeManager.PlayOneShot(soundsEventsSO.openDialogSound);
    public void ChooseOptionSound() => FMODUnity.RuntimeManager.PlayOneShot(soundsEventsSO.chooseOptionSound);
    #endregion
}
