using UnityEngine;
using UnityEngine.UI;
using Alteruna;
using System.Linq;

public class ChatManager : MonoBehaviour
{
    public InputField inputField;
    public TextChatSynchronizable textChatSynchronizable;

    private bool isChatActive = false;

    void Update()
    {
        // T키를 누르면 텍스트 입력 필드 활성화/비활성화
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleChat();
        }

        // 텍스트 입력이 있을 때 명령어 처리
        if (isChatActive && Input.GetKeyDown(KeyCode.Return))
        {
            ProcessCommand(inputField.text);
            inputField.text = ""; // 텍스트 입력 후 초기화
        }
    }

    // 채팅 UI 활성화/비활성화
    private void ToggleChat()
    {
        isChatActive = !isChatActive;
        inputField.gameObject.SetActive(isChatActive);
        if (isChatActive)
        {
            inputField.Select();
            inputField.ActivateInputField();
        }
        else
        {
            inputField.DeactivateInputField();
        }
    }

    // 명령어 처리
    private void ProcessCommand(string command)
    {
        var commandParts = command.Split(' ');
        string mainCommand = commandParts[0];
        string[] args = commandParts.Length > 1 ? commandParts.Skip(1).ToArray() : new string[0];

        // 명령어 처리 예시
        switch (mainCommand.ToLower())
        {
            case "/help":
                textChatSynchronizable.SendChatMessage("Available Commands: /help - Shows help.");
                break;

            // 추가 명령어 처리
            default:
                // Unknown 명령어 처리 없이 그냥 무시할 수 있도록
                break;
        }
    }
}
