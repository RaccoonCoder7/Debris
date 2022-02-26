using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SoundMgr : SingletonMono<SoundMgr>
{
    #region �̱���
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            AwakeAfter();
        }
    }
    #endregion

    public float masterVolumeSFX = 1f;
    public float masterVolumeBGM = 1f;

    public AudioClip BGMClip; // ����� �ҽ��� ����.
    public AudioClip[] audioClip; // ����� �ҽ��� ����.

    Dictionary<string, AudioClip> audioClipsDic;
    AudioSource sfxPlayer;
    AudioSource bgmPlayer;

    void AwakeAfter()
    {
        sfxPlayer = GetComponent<AudioSource>();
        SetupBGM();

        audioClipsDic = new Dictionary<string, AudioClip>();
        foreach (AudioClip a in audioClip)
        {
            audioClipsDic.Add(a.name, a);
        }
    }

    void SetupBGM()
    {
        GameObject child = new GameObject("BGM");
        child.transform.SetParent(transform);
        bgmPlayer = child.AddComponent<AudioSource>();
        bgmPlayer.clip = BGMClip;
        bgmPlayer.volume = masterVolumeBGM;
    }

    private void Start()
    {
        if (bgmPlayer != null)
            bgmPlayer.Play();
    }

    public bool IsBGMPlaying()
    {
        return bgmPlayer ? bgmPlayer.isPlaying : false;
    }

    // �� �� ��� : ���� �Ű������� ����
    public void PlaySound(string a_name, float a_volume = 1f)
    {
        if (audioClipsDic.ContainsKey(a_name) == false)
        {
            Debug.Log(a_name + " is not Contained audioClipsDic");
            return;
        }
        sfxPlayer.PlayOneShot(audioClipsDic[a_name], a_volume * masterVolumeSFX);
    }

    // �������� �� �� ��� : ���� �Ű������� ����
    public void PlayRandomSound(string[] a_nameArray, float a_volume = 1f)
    {
        string l_playClipName;

        l_playClipName = a_nameArray[Random.Range(0, a_nameArray.Length)];

        if (audioClipsDic.ContainsKey(l_playClipName) == false)
        {
            Debug.Log(l_playClipName + " is not Contained audioClipsDic");
            return;
        }
        sfxPlayer.PlayOneShot(audioClipsDic[l_playClipName], a_volume * masterVolumeSFX);
    }

    // �����Ҷ��� ���ϰ��� GameObject�� �����ؼ� �����Ѵ�. ���߿� �ɼǿ��� ���� ũ�� �����ϸ� �̰� ���� �����ؼ� �ٲ�����..
    public GameObject PlayLoopSound(string a_name)
    {
        if (audioClipsDic.ContainsKey(a_name) == false)
        {
            Debug.Log(a_name + " is not Contained audioClipsDic");
            return null;
        }

        bgmPlayer.clip = audioClipsDic[a_name];
        bgmPlayer.volume = masterVolumeSFX;
        bgmPlayer.loop = true;
        bgmPlayer.Play();

        // GameObject l_obj = new GameObject("LoopSound");
        // AudioSource source = l_obj.AddComponent<AudioSource>();
        // source.clip = audioClipsDic[a_name];
        return null;
    }

    // �ַ� ���� ����� ������ ����.
    public void StopBGM()
    {
        bgmPlayer.Stop();
    }

    #region �ɼǿ��� ��������
    public void SetVolumeSFX(float a_volume)
    {
        masterVolumeSFX = a_volume;
    }

    public void SetVolumeBGM(float a_volume)
    {
        masterVolumeBGM = a_volume;
        bgmPlayer.volume = masterVolumeBGM;
    }
    #endregion
}
