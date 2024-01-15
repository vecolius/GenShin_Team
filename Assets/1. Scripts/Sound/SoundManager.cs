using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioMixer mixer;
    public static SoundManager instance;
    public AudioSource bgSound;
    public AudioClip[] bglist;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //scene ���� �� �۵�
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name == "MainMenuScene")
        {
            Debug.Log("OnSceneLoaded" + arg0.name);
            BgSoundPlay(bglist[0]);

        }
        else if (arg0.name == "0911 ����ö")
        {
            Debug.Log("OnSceneLoaded" + arg0.name);
            Debug.Log(arg1);
            BgSoundPlay(bglist[1]);

        }
    }

    //ȿ���� �Լ� -- public AudioClip clip;
    // -- SoundManager.instance.SFXplay("Ŭ����", clip);
    public void SFXplay(string sfName, AudioClip clip)
    {

        GameObject go = new GameObject(sfName + "sound");
        AudioSource audiosource = go.AddComponent<AudioSource>();
        audiosource.outputAudioMixerGroup = mixer.FindMatchingGroups("Effect")[0];
        audiosource.clip = clip;
        audiosource.Play();

        Destroy(go, clip.length);

    }
    //����� �Լ�
    public void BgSoundPlay(AudioClip clip)
    {

        bgSound.outputAudioMixerGroup = mixer.FindMatchingGroups("BGM")[0];
        bgSound.clip = clip;
        bgSound.loop = true;
        bgSound.volume = 0.25f;
        bgSound.Play();

    }
    // Sound Slider
    public void MasterSound(float val)
    {

        mixer.SetFloat("MasterVolume", Mathf.Log10(val) * 20);

    }
}
