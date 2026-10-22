using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    public RectTransform crosshair; // 크로스헤어 UI RectTransform
    public Vector2 firstPersonPosition = new Vector2(0, 0); // 1인칭 크로스헤어 위치
    public Vector2 thirdPersonPosition = new Vector2(0, 50); // 3인칭 크로스헤어 위치
    private bool isFirstPerson = true; // 초기 시점: 1인칭

    private void Update()
    {
        // V 키를 눌러 시점 전환
        if (Input.GetKeyDown(KeyCode.V))
        {
            ToggleView();
        }
    }

    private void ToggleView()
    {
        isFirstPerson = !isFirstPerson;

        if (isFirstPerson)
        {
            SetCrosshairPosition(firstPersonPosition);
            Debug.Log("1인칭 모드로 전환");
        }
        else
        {
            SetCrosshairPosition(thirdPersonPosition);
            Debug.Log("3인칭 모드로 전환");
        }
    }

    private void SetCrosshairPosition(Vector2 position)
    {
        if (crosshair != null)
        {
            crosshair.anchoredPosition = position;
        }
        else
        {
            Debug.LogWarning("크로스헤어가 설정되지 않았습니다.");
        }
    }
}
