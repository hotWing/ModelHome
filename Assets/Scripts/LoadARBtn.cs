using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(Button))]
public class LoadARBtn : MonoBehaviour {

    public GameObject loadingUI;
    public Text loadingText;
    public MediaPlayerCtrl srcMedia;
	void Start () {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(btnOnClick);
	}
	
	void btnOnClick() {
        StartCoroutine(loadARScene());
	}

    IEnumerator loadARScene()
    {
        srcMedia.Stop();
        loadingUI.SetActive(true);
        AsyncOperation ao = SceneManager.LoadSceneAsync("AR");

        while(true)
        {
            int progress = (int)(Mathf.Clamp01((ao.progress / 0.9f)) * 100);
            loadingText.text = progress + "%";
            if (progress >= 100)
                break;
            yield return null;
        }
    }
}
