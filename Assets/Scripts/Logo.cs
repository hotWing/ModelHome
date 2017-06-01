using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour {

    public MediaPlayerCtrl srcMedia;
	void Start ()
    {
        srcMedia.OnEnd += OnVedioEnd;
    }

    void OnDestroy()
    {
        srcMedia.OnEnd -= OnVedioEnd;
    }

    private void OnVedioEnd()
    {
        SceneManager.LoadScene("Main");
    }
}
