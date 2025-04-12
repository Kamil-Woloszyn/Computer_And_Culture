using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections;

public class StudentManager : MonoBehaviour
{
    public TMP_InputField codeInput;
    public TextMeshProUGUI feedbackTMP;
    public string firebaseProjectId = "codelogin-3082d";

    public void OnJoinSession()
    {
        string code = codeInput.text.Trim().ToUpper();

        if (string.IsNullOrEmpty(code))
        {
            feedbackTMP.text = "Please enter a code.";
            return;
        }
        StartCoroutine(CheckSession(code));
    }

    IEnumerator CheckSession(string code)
    {
        string url = $"https://firestore.googleapis.com/v1/projects/{firebaseProjectId}/databases/(default)/documents/sessions/{code}";

        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            feedbackTMP.text = $"Joined session with code: {code}";
        }
        else
        {
            feedbackTMP.text = "Invalid code or session not found.";
            Debug.LogError(request.error);
        }
    }
}
