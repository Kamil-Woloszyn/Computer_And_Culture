using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections;
using System.Text;
using System;
using System.Linq;

public class TeacherManager : MonoBehaviour
{
    public TextMeshProUGUI codeDisplayTMP;

    // Firebase Project ID
    public string firebaseProjectId;

    // Called when the teacher clicks the "Generate Session" button
    public void OnGenerateSession()
    {
        // Generate a random 6-character code comprised of letters and numbers.
        string code = GenerateRandomCode(6);
        // Start the coroutine to create a session in Firebase using this code.
        StartCoroutine(CreateSession(code));
    }

    // create a session in Firebase with the generated code
    IEnumerator CreateSession(string code)
    {
        // The REST API URL to create a document in the "sessions" collection, with the document ID equal to the code.
        string url = $"https://firestore.googleapis.com/v1/projects/{firebaseProjectId}/databases/(default)/documents/sessions/{code}";

        // Prepare the JSON body.store just the creation timestamp
        string json = "{\"fields\": {\"createdAt\": {\"timestampValue\": \"" + DateTime.UtcNow.ToString("o") + "\"}}}";

        // Create a PATCH request
        UnityWebRequest request = new UnityWebRequest(url, "PATCH");
        byte[] body = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(body);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // Send the request and wait for completio
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            if (codeDisplayTMP != null)
            {
                codeDisplayTMP.text = code;
            }
            Debug.Log("Session created successfully with code: " + code);
        }
        else
        {
            // In case of failure, display an error message.
            if (codeDisplayTMP != null)
            {
                codeDisplayTMP.text = "Failed to create session.";
            }
            Debug.LogError("Failed to create session: " + request.error);
        }
    }
    private string GenerateRandomCode(int length)
    {
        // Characters to choose from
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        // Create a new string with a randomly selected character
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[UnityEngine.Random.Range(0, s.Length)]).ToArray());
    }
}
