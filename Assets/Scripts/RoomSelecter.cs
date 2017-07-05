using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomSelecter : MonoBehaviour
{

    private int roomLayer = 8;

    void Update()
    {
        Vector2 pos = -Vector2.one;
#if UNITY_EDITOR
        if (Input.GetMouseButtonUp(0))
        {
            pos = Input.mousePosition;
        }
#else   
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            pos = touch.position;
        }
#endif
        if (pos != -Vector2.one)
        {
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 5000, 1 << roomLayer))
            {
                Transform roomHit = hit.transform;
                string url = roomHit.GetComponent<LinkTo720>().url;
                PlayerPrefs.SetString("url", url);
                SceneManager.LoadScene("Web");
            }
        }
    }
}
