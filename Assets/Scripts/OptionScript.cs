using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionScript : MonoBehaviour
{
    public Resolution[] resolutions;
    //public string resolutionName;
    public Dropdown resolutionSelect;
    public Toggle fullscreenToggle;
    public Text currentRes;


    void Start()
    {
        
        //resolutionSelect.ClearOptions();
        resolutionSelect.onValueChanged.AddListener(delegate { Screen.SetResolution(resolutions[resolutionSelect.value].width, resolutions[resolutionSelect.value].height, false); });


        resolutions = Screen.resolutions;
        
        //currentRes.text = Screen.currentResolution.ToString();
        
        //resolutions = Screen.resolutions.Distinct().OrderBy(x => x.width).ThenBy(x => x.height).ThenBy(x => x.refreshRate).ToArray();
        //resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string resolutionName = resolutions[i].width + " x " + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            //resolutionName[i] = resolutions[i].ToString();
            //resolutionSelect.options[i].text = resolutionName[i];
            resolutionSelect.options.Add(new Dropdown.OptionData(resolutionName));
            //resolutionSelect.value = i;
        }
    }

    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    
    void Update()
    {
        currentRes.text = "Current resolution: " + Screen.width + " x " + Screen.height;
    }
}
