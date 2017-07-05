using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour {

    public MediaPlayerCtrl srcMedia;
    private bool mediaEnded;
	void Start ()
    {
        srcMedia.OnEnd += OnVedioEnd;
        mediaEnded = false;
        StartCoroutine(loadARScene());
    }

    void OnDestroy()
    {
        srcMedia.OnEnd -= OnVedioEnd;
    }

    private void OnVedioEnd()
    {
        mediaEnded = true;
    }

    IEnumerator loadARScene()
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync("AR");
        
        ao.allowSceneActivation = false;
        while(!mediaEnded || ao.progress < 0.9f)
        {
            yield return null;
        }
        ao.allowSceneActivation = true;


    }
}
