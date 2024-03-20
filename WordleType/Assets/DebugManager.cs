using TMPro;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    public static DebugManager Instance;
    [SerializeField] TextMeshProUGUI console;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        console.text = "";
    }

    public void AppendDebugMessage(string text)
    {
        string message = ">> " + text + "\n";
        console.text += message;
    }
}
