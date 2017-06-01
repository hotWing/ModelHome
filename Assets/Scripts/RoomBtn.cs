using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class RoomBtn : MonoBehaviour {

    public string url;
	// Use this for initialization
	void Start () {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(btnOnClick);
	}
	
    void Update()
    {
        transform.forward = Camera.main.transform.forward;
        transform.up = Camera.main.transform.up;
    }

	void btnOnClick () {
        PlayerPrefs.SetString("url", url);
        SceneManager.LoadScene("Web");
    }
}
