using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // SerializeField: private이여도 유니티 Inspector에 보이게 하기
    // private 변수일때는 유니티 Inspector에 안 보임
    // public 변수일때는 유니티 Inspector에 보임
    // 근데 왜 mainMenu, selectMenu 의 변수는 private으로 한 이유는 캡슐화를 위해 한거
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject selectMenu;

    /// <summary>
    /// 게임 씬이 시작했을때 실행되는 함수
    /// </summary>
    private void Awake()
    {
        mainMenu.SetActive(true); // 메인 메뉴 (게임시작, 게임 종료 버튼) 을 켜기
        selectMenu.SetActive(false); // 선택 메뉴 (노래 선택1, 노래 선택2) 을 끄기
    }
    
    /// <summary>
    /// 게임 시작 버튼을 눌렀을때 메인메뉴 버튼은 끄고 노래 선택 버튼 나오게 하기 
    /// </summary>
    public void StartGame()
    {
        mainMenu.SetActive(false); // 메인 메뉴 (게임시작, 게임 종료 버튼) 을 끄기
        selectMenu.SetActive(true); // 선택 메뉴 (노래 선택1, 노래 선택2) 을 켜기
        Debug.Log("Start Game Button CLick"); // 콘솔에 로그 띄우기
    }
}
