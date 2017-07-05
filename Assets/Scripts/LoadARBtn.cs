using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LoadARBtn : MonoBehaviour {

    public GameObject arContent;
    public MediaPlayerCtrl srcMedia;
    public GameObject vedioContent;
	void Start () {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(btnOnClick);

        if (!AppManager.justStarted)
            btnOnClick();

        //srcMedia.SetSpeed(0.5f);
    }

    void btnOnClick() {
        srcMedia.Stop();
        arContent.SetActive(true);
        vedioContent.SetActive(false);
        //StartCoroutine(loadARScene());
    }

    //IEnumerator loadARScene()
    //{
    //    srcMedia.Stop();
    //    loadingUI.SetActive(true);
    //    AsyncOperation ao = SceneManager.LoadSceneAsync("AR");

    //    while(true)
    //    {
    //        int progress = (int)(Mathf.Clamp01((ao.progress / 0.9f)) * 100);
    //        loadingText.text = progress + "%";
    //        if (progress >= 100)
    //            break;
    //        yield return null;
    //    }
    //}
}
