using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System;
// 좀 아름다운 길이의 클래스
// 사실 한번 짜고 안 건들일 예정이라서 클래스 나누기 귀찬았
// 죄송합니디아.....
// 한승쌤한테 결국 혼남
public class MainButtonManager : MonoBehaviour
{
    private GameManager gameManager = null;
    #region Connect 하면 비활성화 되는 버튼들
    [Header("Connect 하면 비활성화되는 버튼들")]
    [SerializeField] private Button quitButton;
    [SerializeField] private Button connectButton;
    #endregion
    #region Connect 하면 활성화되는 UI
    [Header("Connect 하면 활성화되는 버튼들")]
    [SerializeField] private Button levelSelect;
    [SerializeField] private Button achievements;
    [SerializeField] private Button quitConnection;
    [SerializeField] private Button settings;
    [Header("메인 이미지 위치 저장용")]
    [SerializeField] private Image  playerImage;
    #endregion
    #region Connect, Disconnect 하는 중일 때 활성화되는 UI들
    [Header("Connect 하는 중일 때 활성화되는 UI들")]
    [SerializeField] private Text tips;
    [SerializeField] private Text loadingText;
    [Header("Disconnect 하는 중일 때 활성화되는 UI들")]
    [SerializeField] private Text disconnectingText;
    #endregion
    #region 변수들

    private bool     isConnecting    = false;
    private bool     isAtConnectMenu = false;
    private bool     isAtLevelSelect = false;
    private bool     isAtAchievement = false;
    private bool     isAtSettings    = false;
    private bool     isAtPicture     = false;
    private string[] tipsArray;

    [Header("메인화면 렌덤 이미지 용 배열")]
    [SerializeField] private Image[] images;

    [Header("로딩 시간")]
    [SerializeField] private float  connectionTime = 3.0f;
    [Header("화면 전환 시간")]
    [SerializeField] private float  movingTime     = 1.5f;
    [Header("입력 막는 용도")]
    [SerializeField] private Canvas blockInput = null;

    #region 카메라 이동 위한 변수들
    [Header("레벨 선택 위치")]
    [SerializeField] private GameObject levelCameraPoint;
    [Header("업적 상태 위치")]
    [SerializeField] private GameObject achievementPoint;
    [Header("설정 메뉴 위치")]
    [SerializeField] private GameObject settingsPoint;
    [Header("사진 위치")]
    [SerializeField] private GameObject picturePos;
    private readonly Vector3            MAIN_CAMERA_POINT = new Vector3(0.0f, 0.0f, -10.0f);
    #endregion

    #region 버튼 이동 위한 변수들
    [Header("임무 선택 버튼 기본 / 아웃 위치")]
    [SerializeField] private GameObject levelPos;
    [SerializeField] private GameObject levelPosOut;
                     private Vector3    levelTargetPos;
    [Header("업적 버튼 기본 / 아웃 위치")]
    [SerializeField] private GameObject achievePos;
    [SerializeField] private GameObject achievePosOut;
                     private Vector3    achieveTargetPos;
    [Header("게임 종료 버튼 기본 / 아웃 위치")]
    [SerializeField] private GameObject disconPos;
    [SerializeField] private GameObject disconPosOut;
                     private Vector3    disconTargetPos;
    [Header("설정 버튼 기본 / 아웃 위치")]
    [SerializeField] private GameObject setPos;
    [SerializeField] private GameObject setPosOut;
                     private Vector3    setTargetPos;
    [Header("플레이어 기본 / 아웃 위치")]
    [SerializeField] private GameObject imagePos;
    [SerializeField] private GameObject imagePosOut;
                     private Vector3    imageTargetPos;
    #endregion
    #endregion
    
    private void Awake()
    {
        gameManager = GameManager.Instance;
        #region 로딩시 나오는 팁
        {
            tipsArray = new string[9];
            tipsArray[0] = "공격은 나중에 해봅시다...";
            tipsArray[1] = "정식 요원은 연봉이 3억원이라고 해요...";
            tipsArray[2] = "수습 요원은 연봉이 5천만원이라고 해요...";
            tipsArray[3] = "우리 요원은 차가 없어요...";
            tipsArray[4] = "4개발 1아트 팀에서 나온 게임이에요...";
            tipsArray[5] = "...";
            tipsArray[6] = "...이거 읽기는 해요?";
            tipsArray[7] = "크기의 비율을 중시해서 물건 크기가 다 일정해요...";
            tipsArray[8] = "공격은 나중에 해봅시다...";
        }
        #endregion
        #region 버튼 위치 저장 / 미리 정해진 위치로 이동 / 버튼 활성화
        {
            levelTargetPos                    = levelSelect.   transform.position;
            achieveTargetPos                  = achievements.  transform.position;
            disconTargetPos                   = quitConnection.transform.position;
            setTargetPos                      = settings.      transform.position;
            imageTargetPos                    = playerImage.   transform.position;
            levelSelect.   transform.position = levelPos.      transform.position;
            achievements.  transform.position = achievePos.    transform.position;
            quitConnection.transform.position = disconPos.     transform.position;
            settings.      transform.position = setPos.        transform.position;
            playerImage.   transform.position = imagePos.      transform.position;
            levelSelect.   gameObject.SetActive(true);
            achievements.  gameObject.SetActive(true);
            quitConnection.gameObject.SetActive(true);
            settings.      gameObject.SetActive(true);
            playerImage.   gameObject.SetActive(true);
        }
        #endregion
    }

    private void Start()
    {
        if(gameManager.GetMainLoaded())
        {
            quitButton.gameObject.SetActive(false);
            connectButton.gameObject.SetActive(false);
            isConnecting = true;
            loadingText.gameObject.SetActive(true);
            tips.gameObject.SetActive(true);
            Invoke(nameof(WaitComplete), 0f);
        }
    }
    // 벡키용 Update 였던 것
    private void Update()
    {
        switch (isConnecting) // 움직이는 중에 꺼지면 안된다
        {
            case true:
                if (!isAtConnectMenu)
                    blockInput.gameObject.SetActive(true);
                else
                    blockInput.gameObject.SetActive(false);
                break;
            case false:
                blockInput.gameObject.SetActive(false);
                OnEscape();
                break;
        }
    }


    #region 버튼에서 사용하는 함수들
    #region 멋 용도로 만들어진 로딩화면
    /// <summary>
    /// 서버스럽지만 전혀 서버와 접속하는 함수 이름이 아니라는 함정
    /// </summary>
    public void BeginConnect()
    {
        quitButton.   gameObject.SetActive(false);
        connectButton.gameObject.SetActive(false);
        ConnectingToND();
    }
    public void ConnectingToND() // 멋 위한 코드
    {
        if (!gameManager.GetMainLoaded())
        {
            isConnecting = true;
            gameManager.SetMainLoaded(true);
            loadingText.gameObject.SetActive(true);
            RandomlyPickTip();
            tips.gameObject.SetActive(true);
            Invoke(nameof(WaitComplete), connectionTime);
        }
        else
        {
            WaitComplete();
        }
    }
    private void WaitComplete()
    {
        loadingText.gameObject.SetActive(false);
        tips.gameObject.SetActive(false);
        isAtConnectMenu = true;
        

        LoadNDServer();
    }
    #endregion
    #region 메인 화면
    private void LoadNDServer() // 서버가 들어갔지만 전혀 서버와 관련 없는 함수
    {
        isConnecting = true;

        RandomlyPickImage();

        levelSelect.   transform.position = levelPos.  transform.position;
        achievements.  transform.position = achievePos.transform.position;
        quitConnection.transform.position = disconPos. transform.position;

        levelSelect.   transform.DOMove(levelTargetPos,   movingTime).       SetEase(Ease.OutCubic);
        achievements.  transform.DOMove(achieveTargetPos, movingTime + 0.1f).SetEase(Ease.OutCubic);
        settings.      transform.DOMove(setTargetPos,     movingTime + 0.2f).SetEase(Ease.OutCubic);
        quitConnection.transform.DOMove(disconTargetPos,  movingTime + 0.2f).SetEase(Ease.OutCubic);
        playerImage   .transform.DOMove(imageTargetPos,   movingTime - 0.2f).SetEase(Ease.OutCubic).OnComplete(MoveComplete);
    }
    public void QuitNDServer()
    {
        isConnecting = true;

        levelSelect.   transform.DOMove(levelPosOut.  transform.position, movingTime).       SetEase(Ease.OutCubic);
        achievements.  transform.DOMove(achievePosOut.transform.position, movingTime + 0.1f).SetEase(Ease.OutCubic);
        quitConnection.transform.DOMove(disconPosOut. transform.position, movingTime + 0.2f).SetEase(Ease.OutCubic);
        settings.      transform.DOMove(setPosOut.    transform.position, movingTime + 0.2f).SetEase(Ease.OutCubic);
        playerImage.   transform.DOMove(imagePosOut.  transform.position, movingTime - 0.2f).SetEase(Ease.OutCubic).OnComplete(MoveComplete);


        if (!gameManager.GetMainLoaded())
        {
            disconnectingText.gameObject.SetActive(true);
            RandomlyPickTip();
            tips.gameObject.SetActive(true);

            Invoke(nameof(DisconnectComplete), connectionTime);
        }
        else
        {
            ReturnToMainmenu();
        }
    }
    private void DisconnectComplete()
    {
        disconnectingText.gameObject.SetActive(false);
        tips.gameObject.SetActive(false);
        ReturnToMainmenu();
    }
    #endregion
    #region 본격적인 정보창

    #region 임무, 업적, 설정, 사진
    public void GotoLevelSelect()
    {
        isConnecting    = true;
        isAtLevelSelect = true;
        isAtConnectMenu = false;
        Camera.main.transform.DOMove(levelCameraPoint.transform.position, movingTime).SetEase(Ease.OutCubic).OnComplete(MoveComplete);
    }
    public void GotoAchievements()
    {
        isConnecting    = true;
        isAtAchievement = true;
        isAtConnectMenu = false;
        Camera.main.transform.DOMove(achievementPoint.transform.position, movingTime).SetEase(Ease.OutCubic).OnComplete(MoveComplete);
    }
    public void GotoSettings()
    {
        isConnecting    = true;
        isAtSettings    = true;
        isAtConnectMenu = false;
        Camera.main.transform.DOMove(settingsPoint.transform.position, movingTime).SetEase(Ease.OutCubic).OnComplete(MoveComplete);
    }
    public void GotoPicture()
    {
        if(!isAtPicture && isAtConnectMenu)
        {
            playerImage.transform.DOMove(imagePosOut.transform.position, movingTime).SetEase(Ease.OutCubic);
            isConnecting = true;
            isAtConnectMenu = false;
            isAtPicture = true;
            Camera.main.transform.DOMove(picturePos.transform.position, movingTime).SetEase(Ease.OutCubic).OnComplete(MoveComplete);
        }
    }
    #endregion

    private void ReturnPosToMainMenu()
    {
        if (isAtPicture)
        {
            playerImage.transform.DOMove(imageTargetPos, movingTime).SetEase(Ease.OutCubic);
        }
        isAtConnectMenu = true;
        isConnecting    = true;
        isAtAchievement = false;
        isAtLevelSelect = false;
        isAtPicture     = false;
        isAtSettings    = false;
        Camera.main.transform.DOMove(MAIN_CAMERA_POINT, movingTime).SetEase(Ease.OutCubic).OnComplete(MoveComplete);
    }
    
    public void EnterStage1()
    {
        SceneManager.LoadScene("Stage1Load");
    }
    public void EnterStage2()
    {
        SceneManager.LoadScene("Stage2Load");
    }

    private void MoveComplete()
    {
        isConnecting = false;
    }

    #endregion
    private void QuitOperationPicture()
    {
        #region 유니티 에디터일때만
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        #endregion
        #region 유니티 에디터가 아닐때만
#if !UNITY_EDITOR
        Application.Quit();
#endif
        #endregion
    }
    #endregion


    // 끄는 용도
    /// <summary>
    /// 맨 처음으로 돌아감
    /// </summary>
    public void ReturnToMainmenu()
    {
        quitButton.gameObject.SetActive(true);
        connectButton.gameObject.SetActive(true);
        isAtConnectMenu = false;
    }
    private void OnEscape()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            BackButton();
        }
        return;
    }
    public void BackButton()
    {
        switch (isAtConnectMenu)
        {
            case true:
                QuitNDServer();
                return;
            case false:
                if (isAtAchievement || isAtLevelSelect || isAtSettings || isAtPicture)
                {
                    ReturnPosToMainMenu();
                    return;
                }
                QuitOperationPicture();
                return;
        }
    }

    // 랜덤으로 tipsArray 에서 불러온 원소를 tips 에 넣음
    private void RandomlyPickTip()
    {
        int tip = (int)UnityEngine.Random.Range(0.0f, 8.5f);
        tips.text = tipsArray[tip];
    }

    private void RandomlyPickImage()
    {
        int image = (int)UnityEngine.Random.Range(0.0f, 5.5f);
        playerImage.sprite = images[image].sprite;
    }

}