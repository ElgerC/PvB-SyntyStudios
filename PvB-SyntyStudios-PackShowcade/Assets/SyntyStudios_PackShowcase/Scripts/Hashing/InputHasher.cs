using UnityEngine;
using System.IO;
using TMPro;

public class InputHasher : MonoBehaviour
{
    [SerializeField] private TMP_InputField emailInput;
    [SerializeField] private TMP_InputField userNameInput;

    public void Submit()
    {
        EnterUser(userNameInput.text,emailInput.text);
    }

    private static string SavePath =>
        Path.Combine(Application.persistentDataPath, "user.json");

    public void EnterUser(string userName, string Email)
    {
        var user = new UserData
        {
            userName = userName,
            Email = Email
        };

        string json = JsonUtility.ToJson(user, true);
        File.WriteAllText(SavePath, json);
        Debug.Log(SavePath);
    }
}
