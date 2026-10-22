using System.Collections.Generic;
using UnityEngine;

public class AimPracticeSpawner : MonoBehaviour
{
    public GameObject spherePrefab; // 생성할 스피어 프리팹
    public float spawnInterval = 2f; // 스피어 생성 간격
    public float fixedX = 5f; // X 위치 고정값
    public Vector2 yRange = new Vector2(-3f, 3f); // Y축 범위
    public Vector2 zRange = new Vector2(-3f, 3f); // Z축 범위
    public float sphereRadius = 0.5f; // 스피어의 반경
    public Transform FirePoint; // 발사 지점 Transform (총구)

    private List<GameObject> spheres = new List<GameObject>(); // 생성된 스피어 리스트
    private float spawnTimer; // 생성 타이머
    private bool canFire = true; // 총알 발사 가능 여부

    private void Update()
    {
        // ESC 키 입력으로 발사 토글
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleFireStatus(); // 발사 가능 여부 토글
        }

        // 스피어 생성 타이머
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnSphere();
            spawnTimer = 0f;
        }

        // 발사 키 입력 처리
        if (Input.GetKeyDown(KeyCode.Mouse0) && canFire) // 마우스 왼쪽 버튼 클릭
        {
            CheckSphereHit();
        }
    }

    private void SpawnSphere()
    {
        // Y축과 Z축에서 랜덤 위치 계산
        float randomY = Random.Range(yRange.x, yRange.y);
        float randomZ = Random.Range(zRange.x, zRange.y);

        Vector3 spawnPosition = new Vector3(fixedX, randomY, randomZ);

        // 스피어 생성
        GameObject newSphere = Instantiate(spherePrefab, spawnPosition, Quaternion.identity);

        // 반경 설정 (Sphere Collider가 있어야 함)
        SphereCollider sphereCollider = newSphere.GetComponent<SphereCollider>();
        if (sphereCollider != null)
        {
            sphereCollider.radius = sphereRadius; // 반경 설정
        }

        // 리스트에 추가
        spheres.Add(newSphere);
    }

    public void CheckSphereHit()
    {
        if (FirePoint == null)
        {
            Debug.LogError("FirePoint가 설정되지 않았습니다!");
            return;
        }

        // FirePoint에서 Ray 발사
        Vector3 rayOrigin = FirePoint.position;
        Vector3 rayDirection = FirePoint.forward;

        Debug.DrawRay(rayOrigin, rayDirection * 100f, Color.red, 2f); // 레이 확인

        if (Physics.Raycast(rayOrigin, rayDirection, out RaycastHit hit, 100f)) // 100 유닛 길이
        {
            GameObject hitObject = hit.collider.gameObject;

            // 스피어가 맞았는지 확인
            if (spheres.Contains(hitObject))
            {
                Debug.Log($"스피어 {hitObject.name}에 명중!");
                spheres.Remove(hitObject);
                Destroy(hitObject);
            }
        }
        else
        {
            Debug.Log("레이캐스트가 아무것도 맞추지 못했습니다.");
        }
    }

    // 발사 상태 토글
    public void ToggleFireStatus()
    {
        canFire = !canFire;
        string status = canFire ? "활성화" : "비활성화";
        Debug.Log($"총알 발사 {status}");
    }

    // CONTINUE 버튼 클릭 시 발사 활성화
    public void EnableFire()
    {
        canFire = true;
        Debug.Log("CONTINUE 버튼으로 총알 발사 활성화!");
    }
}
