using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameConfigManager : MonoBehaviour
{
    public DataPersistanceManager dpm;
    public AudioManager audioManager;

    [Header("Music")]
    [SerializeField] TextMeshProUGUI[] VolumeUITex;
    [SerializeField] Scrollbar[] VolumeScrollbar;

    [Header("Text")]
    [SerializeField] TextMeshProUGUI textSpeedUIText;
    [SerializeField] Scrollbar textSpeedScrollbar;

    [Header("Idioma")]
    [SerializeField] Toggle toggleEsp;
    [SerializeField] Toggle toggleEng;

    //float volumeValue;
    //float textSpeed;
    private void Start() {
        for (int i = 0; i < 3; i++)
        {
            GetMusicVolume(i);
        }
        //GetTextSpeed();
        //GetIdioma();
    }

    public void SetNewMusicVolume(int settingID){
       
        int newVolume = (int) (VolumeScrollbar[settingID].value * 100);
        VolumeUITex[settingID].text = newVolume.ToString() + "%";
        audioManager.setNewVolume(settingID, VolumeScrollbar[settingID].value);

        //Debug.Log("New volume = " + newVolume);

        dpm.SaveSpecificData(Data.BG_VOL, VolumeScrollbar[settingID].value);
    }

    public void SetNewTextSpeed(){
        int newSpeed = (int) (textSpeedScrollbar.value * 100);
        if(newSpeed < 30){
            textSpeedUIText.text = "Low";
        }else if(newSpeed < 60){
            textSpeedUIText.text = "Med.";
        }else if(newSpeed < 90){
            textSpeedUIText.text = "High";
        }else{
            textSpeedUIText.text = "None";
        }

        dpm.SaveSpecificData(Data.TEXT_SPEED, newSpeed);
    }

    public void SetNewIdioma(string idiomaID){
        int nuevoIdioma = -1;
        if(idiomaID == "ES" && toggleEsp.isOn){
            toggleEsp.interactable = false;
            toggleEng.interactable = true;
            toggleEng.isOn = false;
            nuevoIdioma = 1;
        }else if(idiomaID == "EN" && toggleEng.isOn){
            toggleEng.interactable = false;
            toggleEsp.interactable = true;
            toggleEsp.isOn = false;
            nuevoIdioma = 0;
        }
        else{
            return;
        }

        //Debug.Log("New idioma = " + idiomaID);

        dpm.SaveSpecificData(Data.IDIOMA, nuevoIdioma);
    }

    public void GetMusicVolume(int settingID){
        if(VolumeUITex[0] == null || VolumeUITex.Length <= 0){
            Debug.LogWarning("Trying to get mussic volume but no assets were given. GameConfigManager ln 85.");
        }else{
            float volume = audioManager.getVolumeValue(settingID);
            VolumeUITex[settingID].text = ((int) (100 * volume)).ToString() + "%";
            VolumeScrollbar[settingID].value = volume;
        }
    }

}
