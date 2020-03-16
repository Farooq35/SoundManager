using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class _AudioManagerF : MonoBehaviour
{
    #region Enum for Place Point
    public enum BGscreen
{
        MainMenu,
        Selection,
        Gameplay,
        loading
}
    #endregion

    #region Instances
    private static _AudioManagerF instance = null;

    public static _AudioManagerF _Ins
    {
        get
        {
            if(instance == null)
            {
                return instance = new _AudioManagerF();
            }
            else
            {
                return instance;
            }
        }

    }
    #endregion

    #region AudioClips For Play
    [Header("Audio Clips For play")]

    [SerializeField]
    private AudioClip Music_MainMenu;
    [SerializeField]
    private AudioClip Music_Loading, Music_GamePlay, Music_selection, Music_BtnClick, Music_GameFail, Music_GameComplete;
    #endregion

    #region Audio Sources
    [Header("Audio Sources")]

    [SerializeField]
    private AudioSource AudSrc_BGmusic;


    [SerializeField]
    private AudioSource AudSrc_BTNClick, AudSrc_Extrasound;
    #endregion

    #region Strings For Music On Off
    const string STR_sound = "sounds";
    const string STR_music = "music";
    const string STR_volume = "MasterVolume";
    #endregion

    #region Default Functions
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt(STR_music, 0) == 0)
        {
            AudSrc_BGmusic.volume = 1f;
        }
        else
        {
            AudSrc_BGmusic.volume = 0f;

        }
        if (PlayerPrefs.GetInt(STR_sound, 0) == 0)
        {
            AudSrc_BTNClick.volume = 1f;

        }
        else
        {
            AudSrc_BTNClick.volume = 0f;

        }

        AudioListener.volume = PlayerPrefs.GetFloat(STR_volume,1);
    }

    #endregion

    #region UserDefined Functions

    public void _OffMusic(bool On)
    {
        if (!On)
        {
            PlayerPrefs.SetInt(STR_music, 10);
            AudSrc_BGmusic.volume = 0f;
        }
        else
        {
            PlayerPrefs.SetInt(STR_music, 0);
            AudSrc_BGmusic.volume = 1f;

        }
    }
    public void _OffSound(bool On)

    {
        if (!On)
        {
            PlayerPrefs.SetInt(STR_sound, 10);
            AudSrc_BTNClick.volume = 0f;

        }
        else
        {
            PlayerPrefs.SetInt(STR_sound, 0);
            AudSrc_BTNClick.volume = 1f;

        }
    }

    public void _VolumeSet(float vol)
    {
        AudioListener.volume = vol;

        PlayerPrefs.SetFloat(STR_volume, vol);

    }
    public void _AllGameSoundsOff()
    {
        AudioListener.pause = true;
    }
    public void _AllGameSoundsOn()
    {
        AudioListener.pause = false;
    }
    public void _Play_extraMusics(AudioClip PlayableClip)
    {
        if (AudSrc_Extrasound.isPlaying)
            AudSrc_Extrasound.Stop();
        if (PlayerPrefs.GetInt(STR_sound, 0) == 0)
        {
            AudSrc_Extrasound.clip = PlayableClip;

            AudSrc_Extrasound.Play();
        }
    }
    public void _PlayBTN_music()
    {
        if (AudSrc_BTNClick.isPlaying)
            AudSrc_BTNClick.Stop();

        if (PlayerPrefs.GetInt(STR_sound, 0) == 0)
        {
            AudSrc_BTNClick.clip = Music_BtnClick;

            AudSrc_BTNClick.Play();
        }
    }
    public bool getSoundOn
    {
        get
        {
            if (PlayerPrefs.GetInt(STR_sound, 0)==0)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
    }
    public bool getMusicOn
    {
        get
        {
            if (PlayerPrefs.GetInt(STR_music, 0) == 0)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
    }
    public float getVolume
    {
        get
        {

            return PlayerPrefs.GetFloat(STR_volume, 1);
        }
    }
    public void _PlayBG_music(BGscreen bGscreen)
    {
        if (AudSrc_BGmusic.isPlaying)
            AudSrc_BGmusic.Stop();
        if (PlayerPrefs.GetInt(STR_music, 0) == 0)
        {
            switch (bGscreen)
            {
                case BGscreen.MainMenu:
                    AudSrc_BGmusic.clip = Music_MainMenu;
                    break;

                case BGscreen.Gameplay:
                    AudSrc_BGmusic.clip = Music_GamePlay;
                    break;

                case BGscreen.Selection:
                    AudSrc_BGmusic.clip = Music_selection;
                    break;

                case BGscreen.loading:
                    AudSrc_BGmusic.clip = Music_Loading;

                    break;
            }
            AudSrc_BGmusic.Play();
        }
    }

    #endregion

}
