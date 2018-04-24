using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour {

    public Slider volume;
    public Toggle isFullscreen;

	void Start () {

        volume.value = AudioListener.volume;
        volume.onValueChanged.AddListener(delegate { OnVolumeValueChange(); });

        isFullscreen.isOn = Screen.fullScreen;
        isFullscreen.onValueChanged.AddListener(delegate { FullscreenValueChange(); });

	}
	
    public void FullscreenValueChange()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

	public void OnVolumeValueChange()
    {
        AudioListener.volume = volume.value;
    }
}
