using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FinalRoom : MonoBehaviour
{
    [SerializeField]
    GameObject currentcam, finalCam, finalPart, audioSou, oldAudio;
    public static bool endGame;
    private void Start()
    {
        endGame = false;
    }
    private void Update()
    {
        Debug.Log(endGame);
        if (endGame == true)
        {
            currentcam.SetActive(false);
            finalCam.SetActive(true);
            finalPart.SetActive(true);
            audioSou.SetActive(true);
            oldAudio.SetActive(false);
        }
    }
}
