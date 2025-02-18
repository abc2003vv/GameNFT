using UnityEngine;
using UnityEngine.UI;  // Đảm bảo bạn có sử dụng Unity UI
using UnityEngine.Networking;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class APIManager : MonoBehaviour
{
    // Địa chỉ API backend Node.js
    private string apiBaseUrl = "http://localhost:3000";

    // Các tham chiếu UI
    public TMP_InputField emailInput;  // InputField cho email
    public Button registerButton;  // Button đăng ký
    public Button loginButton;  // Button đăng nhập

    void Start()
    {
        // Gọi Coroutine để thực thi TestAPIConnection
        StartCoroutine(TestAPIConnection());
    }

    IEnumerator TestAPIConnection()
    {
        // Tạo yêu cầu GET
        using (UnityWebRequest request = UnityWebRequest.Get(apiBaseUrl))
        {
            // Gửi yêu cầu và đợi kết quả
            yield return request.SendWebRequest();

            // Kiểm tra nếu yêu cầu thành công
            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("API Connection Successful!");
                Debug.Log("Response: " + request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("API Connection Failed: " + request.error);
            }
        }
    }

    // Khi người dùng nhấn Button Đăng ký, gọi hàm này
    public void OnRegisterButtonClick()
    {
        string email = emailInput.text;
        RegisterUser(email);
    }

    // Khi người dùng nhấn Button Đăng nhập, gọi hàm này
    public void OnLoginButtonClick()
    {
        string email = emailInput.text;
        LoginUser(email);
    }

    // Đăng ký người dùng mới
    public void RegisterUser(string email)
    {
        StartCoroutine(RegisterUserRequest(email));
    }

    // Đăng nhập người dùng
    public void LoginUser(string email)
    {
        StartCoroutine(LoginUserRequest(email));
    }

    // Gửi request POST để đăng ký user
    IEnumerator RegisterUserRequest(string email)
    {
        string json = "{\"gmail\":\"" + email + "\"}";
        byte[] body = System.Text.Encoding.UTF8.GetBytes(json);

        using (UnityWebRequest request = new UnityWebRequest(apiBaseUrl + "/users", "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(body);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("User registered: " + request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error registering user: " + request.error);
            }
        }
    }

    // Gửi request POST để đăng nhập user
    IEnumerator LoginUserRequest(string email)
    {
        // Tạo dữ liệu JSON
        string json = "{\"gmail\":\"" + email + "\"}";
        byte[] body = System.Text.Encoding.UTF8.GetBytes(json);

        // Sử dụng POST request thay vì GET
        using (UnityWebRequest request = new UnityWebRequest(apiBaseUrl + "/users/login", "POST"))
        {
            // Gửi dữ liệu JSON vào body của request
            request.uploadHandler = new UploadHandlerRaw(body);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            // Gửi request và đợi kết quả
            yield return request.SendWebRequest();

            // Kiểm tra kết quả
            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("User logged in: " + request.downloadHandler.text);
                SceneManager.LoadScene("MainGame");
            }
            else
            {
                Debug.LogError("Error logging in: " + request.error);
            }
        }
    }

}
