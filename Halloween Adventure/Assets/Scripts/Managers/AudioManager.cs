using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IDataPersistance
{
    public AudioSource[] bgMusicSource;
    public AudioSource[] fxSource;
    public AudioSource[] voiceSource;

    public DataPersistanceManager dpm;

    float bgMusicVolume;
    float fxVolume;
    float voiceVolume;
    
    public bool loaded;
    
    private void Start() {
        loaded = false;
    }

    public void setNewVolume(int audioCategory, float newVolume){
        switch(audioCategory){
            case 0:
                foreach(AudioSource clip in bgMusicSource){
                    clip.volume = newVolume;
                }
                bgMusicVolume = newVolume;
                dpm.SaveSpecificData(Data.BG_VOL, newVolume);
                break;
            case 1:
                foreach(AudioSource clip in fxSource){
                    clip.volume = newVolume;
                }
                fxVolume = newVolume;
                dpm.SaveSpecificData(Data.FX_VOL, newVolume);
                break;
            case 2:
                foreach(AudioSource clip in voiceSource){
                    clip.volume = newVolume;
                }
                voiceVolume = newVolume;
                dpm.SaveSpecificData(Data.VOICE_VOL, newVolume);
            break;
        }
    }

    public float getVolumeValue(int audioSettingId){
        if(!loaded) Debug.LogWarning("Can't get volume value, still not loaded");
        if(audioSettingId == 0){
            return bgMusicVolume;
        }else if(audioSettingId == 1){
            return fxVolume;
        }else if(audioSettingId == 2){
            return voiceVolume;
        }else{
            Debug.LogWarning("Getting an invalid volume value");
            return -1f;
        }
    }

    public void LoadData(GameData data){
        bgMusicVolume = data.volumeBG;
        fxVolume = data.volumeFX;
        voiceVolume = data.volumeVoice;
        loaded = true;
    }

    public void SaveData(ref GameData data){
        data.volumeBG = bgMusicVolume;
        data.volumeFX = fxVolume;
        data.volumeVoice = voiceVolume;
    }
}
