using UnityEngine;
using UnityEngine.UI;// 유아이 관련 도구
using UnityEngine.SceneManagement; // 씬관리 도구
using JetBrains.Annotations;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverText;
    public Text timeText;
    public Text recordText;

    private float surviveTime;
    private bool isGameover;

    void Start()
    {
        surviveTime = 0;
        isGameover = false;

    }

    // Update is called once per frame
    void Update()
    {    // 게임오버가 아닌 동안
        if (!isGameover)
        {
            // 생존시간 갱신
            surviveTime += Time.deltaTime;
            // 갱신한 생존기간을 timetext 컴포먼트를 이용해 표시
            timeText.text = "Time : " + (int)surviveTime;

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                // 샘신을 로드
                SceneManager.LoadScene("SampleScene");
            }
        }

    }
     public void EndGame()
    {
        // 현재상태를 게임오버상태로 전환
        isGameover = true;
        // 게임오버 테스트를  오브젝트를 활당(코드로 접근: 스크럽트 set 클릭)
        GameOverText.SetActive(true);

        // 베스트 타임키로 저장된 이전까지의 최고기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);

        }

        recordText.text = "Best Time : " + (int)bestTime;
    }

}
