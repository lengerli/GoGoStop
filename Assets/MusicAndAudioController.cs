using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAndAudioController : MonoBehaviour
{
    public GameObject muteButton;
    public GameObject unMuteButton;

    void Start()
    {
        unMuteButton.SetActive(false);
        muteButton.SetActive(false);

        if (GameObject.FindGameObjectsWithTag(this.gameObject.tag).Length > 1)
        {
            foreach(GameObject audioControls in GameObject.FindGameObjectsWithTag(this.gameObject.tag))
            {
                if (!audioControls.Equals(this.gameObject))
                {
                    this.GetComponent<AudioSource>().mute = audioControls.GetComponent<AudioSource>().mute;
                    Destroy(audioControls);
                }
            }

            if (this.GetComponent<AudioSource>().mute == true)
                unMuteButton.SetActive(true);
            else
                muteButton.SetActive(true);

        }
        else
            muteButton.SetActive(true);
        

        DontDestroyOnLoad(gameObject);

    }
}
