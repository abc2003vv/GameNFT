using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AuthManager : MonoBehaviour
{
    private string apiUrl = "http://localhost:3000/auth/login"; // API backend

    public void Login(string email, string password)
    {
        StartCoroutine(LoginRequest(email, password));
    }

    IEnumerator LoginRequest(string email, string password)
    {
        string json = "{\"gmail\":\"" + email + "\", \"password\":\"" + password + "\"}";
        byte[] body = System.Text.Encoding.UTF8.GetBytes(json);

        using (UnityWebRequest request = new UnityWebRequest(apiUrl, "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(body);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Login success: " + request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Login failed: " + request.error);
            }
        }
    }
}
