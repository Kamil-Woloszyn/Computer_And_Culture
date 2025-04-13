using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Text;
using System.Collections;
using TMPro;

public class StudentManager : MonoBehaviour
{
    // Input fields for the session code and student name
    public TMP_InputField codeInput;
    public TMP_InputField studentNameInput;

    // Firebase project ID
    public string firebaseProjectId = "your-project-id";

    // This method gets called when the Join Session button is clicked
    public void OnJoinSession()
    {
        string code = codeInput.text.Trim().ToUpper();
        string studentName = studentNameInput.text.Trim();

        if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(studentName))
        {
            Debug.LogError("Both session code and student name must be entered.");
            return;
        }

        StartCoroutine(CheckAndUpdateSession(code, studentName));
    }

    IEnumerator CheckAndUpdateSession(string code, string studentName)
    {
        //Firestore URL for the session document
        string url = $"https://firestore.googleapis.com/v1/projects/{firebaseProjectId}/databases/(default)/documents/sessions/{code}";

        // perform a GET request to check that the session exists.
        UnityWebRequest getRequest = UnityWebRequest.Get(url);
        getRequest.SetRequestHeader("Content-Type", "application/json");
        yield return getRequest.SendWebRequest();

        if (getRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Session not found or network error: " + getRequest.error);
            yield break;
        }

        // Generate a unique key for this student entry
        string uniqueKey = "student_" + DateTime.UtcNow.Ticks;
        // Get the join time in ISO 8601 format.
        string joinTime = DateTime.UtcNow.ToString("o");

        // Build the JSON payload for updating with this student's data
        string json = "{\"fields\": {" +
                      "\"" + uniqueKey + "\": {" +
                          "\"mapValue\": {" +
                              "\"fields\": {" +
                                  "\"name\": {\"stringValue\": \"" + studentName + "\"}," +
                                  "\"joinedAt\": {\"timestampValue\": \"" + joinTime + "\"}" +
                              "}" +
                          "}" +
                      "}" +
                      "}}";

        // add update mask query parameter with the unique key
        string urlWithMask = url + $"?updateMask.fieldPaths={uniqueKey}";

        // Create a PATCH request using the merged URL
        UnityWebRequest patchRequest = new UnityWebRequest(urlWithMask, "PATCH");
        byte[] body = Encoding.UTF8.GetBytes(json);
        patchRequest.uploadHandler = new UploadHandlerRaw(body);
        patchRequest.downloadHandler = new DownloadHandlerBuffer();
        patchRequest.SetRequestHeader("Content-Type", "application/json");

        yield return patchRequest.SendWebRequest();

        if (patchRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Student added: " + studentName + " joined at " + joinTime);
            // Switch screenss
            UI_Manager.Singleton.ChangeUITab(UI_Tabs.MAIN_MENU_STUDENT_SCREEN);
        }
        else
        {
            Debug.LogError("Failed to update session: " + patchRequest.error);
        }
    }
}
