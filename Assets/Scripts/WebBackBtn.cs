using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class WebBackBtn : MonoBehaviour
{
    public GameObject loadingUI;
    public Text loadingText;
    // Use this for initialization
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(btnOnClick);
    }

    private void btnOnClick()
    {
        StartCoroutine(loadARScene());
    }

    IEnumerator loadARScene()
    {
        loadingUI.SetActive(true);
        AsyncOperation ao = SceneManager.LoadSceneAsync("AR");
        while (true)
        {
            int progress = (int)(Mathf.Clamp01((ao.progress / 0.9f)) * 100);
            loadingText.text = progress + "%";
            if (progress >= 100)
                break;
            yield return null;
        }
    }
}
