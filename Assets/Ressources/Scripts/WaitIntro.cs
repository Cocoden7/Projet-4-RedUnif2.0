using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class WaitIntro : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public float VideoTime = 12f; 

    private void Start()
    {
        videoPlayer = GameObject.FindGameObjectWithTag("Video").GetComponent<VideoPlayer>();
        StartCoroutine(WaitForIntro());
    }

    IEnumerator WaitForIntro()
    {
        yield return new WaitForSeconds(VideoTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        print("video finie");
    }
}
