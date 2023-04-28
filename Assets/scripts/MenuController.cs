using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public UnityEngine.UI.Text ui_text;

    public void RetrieveBtn()
    {
        string url = BaseURL() + "img/";
        StartCoroutine(DownloadImage(url));
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        MediaUrl = "https://www.testxr.org/my_staticfiles/images/landing/Logo_SFtestXR.png";
        UnityEngine.Networking.UnityWebRequest request = UnityEngine.Networking.UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            Debug.Log("worked");
    }

    private string BaseURL()
    {
        return SystemInfo.deviceUniqueIdentifier.ToString().Substring(0, 4).ToLower() + "/";
    }

    private void Start()
    {
        ui_text.text += BaseURL();

    }
}
