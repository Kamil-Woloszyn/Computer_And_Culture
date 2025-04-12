using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System;
using TMPro;
using System.Collections;

public class TeacherManager : MonoBehaviour
{
    public TMP_InputField codeInput;
    // Reference to the TMP Text for feedback
    public TextMeshProUGUI feedbackTMP;
    public string firebaseProjectId = "codelogin-3082d";

    public void OnCreateSession()
    {
        string code = codeInput.text.Trim().ToUpper();

        if (string.IsNullOrEmpty(code))
        {
            feedbackTMP.text = "Please enter a code.";
            return;
        }
        StartCoroutine(CheckAndCreateSession(code));
    }

    IEnumerator CheckAndCreateSession(string code)
    {
        string url = $"https://firestore.googleapis.com/v1/projects/{firebaseProjectId}/databases/(default)/documents/sessions/{code}";

        // Check if code exists
        UnityWebRequest getRequest = UnityWebRequest.Get(url);
        getRequest.SetRequestHeader("Content-Type", "application/json");
        yield return getRequest.SendWebRequest();

        if (getRequest.result == UnityWebRequest.Result.Success)
        {
            feedbackTMP.text = "Code already exists. Try another.";
            yield break;
        }

        // Create the session if code doesn't exist
        string json = "{\"fields\": {\"createdAt\": {\"timestampValue\": \"" + DateTime.UtcNow.ToString("o") + "\"}}}";
        UnityWebRequest putRequest = new UnityWebRequest(url, "PATCH");
        byte[] body = Encoding.UTF8.GetBytes(json);
        putRequest.uploadHandler = new UploadHandlerRaw(body);
        putRequest.downloadHandler = new DownloadHandlerBuffer();
        putRequest.SetRequestHeader("Content-Type", "application/json");

        yield return putRequest.SendWebRequest();

        if (putRequest.result == UnityWebRequest.Result.Success)
        {
            feedbackTMP.text = $"Session created with code: {code}";
        }
        else
        {
            feedbackTMP.text = "Failed to create session.";
            Debug.LogError(putRequest.error);
        }
    }
}
