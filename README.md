# What-A-Scrub

Alteruna 멀티플레이 FPS 템플릿을 바탕으로 만든 **멀티플레이 FPS**입니다.

- 2024년 12월, '게임콘텐츠제작' 기말 프로젝트
- Unity 6000.3.2f1 · C# · Alteruna Multiplayer

## 직접 만든 부분과 가져온 부분

| 구분 | 내용 |
|---|---|
| 템플릿에서 가져옴 | 방 매칭 화면, 총을 든 캐릭터, 점수판 ([Alteruna Multiplayer FPS Template](https://assetstore.unity.com/packages/templates/systems/multiplayer-fps-template-259143)) |
| 외부 에셋 | 맵(RPG FPS game assets industrial), Devion Games UI |
| 직접 만듦 | 그 밖의 부분 (로그인 화면, 메뉴, 사격 연습장, 크로스헤어, 채팅 등) |

## 이 저장소에 있는 파일

```
Assets/AlterunaFPS/
  Scenes/       Login_Process, Login_success, Menu, Multiplayer, Practice
  Scripts/      AimPracticeSpawner(연습장 표적 생성·명중 처리), ChatManager(채팅·명령어),
                CrosshairController(크로스헤어), ResizeController(UI 크기 조정), PlayerStats
  Prefab/       Player_cross, Sphere(연습장 표적)
  Practice_Wall.mat
```

## 포함하지 않은 파일

템플릿과 외부 에셋은 라이선스 때문에 저장소에 넣지 않았습니다. 프로젝트를 열려면 Alteruna SDK, Alteruna Multiplayer FPS Template, 맵 에셋이 필요합니다. 실행 파일은 Releases에 올립니다.

README와 `.gitignore` 정리는 Claude(AI)의 도움을 받았습니다.
