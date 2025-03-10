using UnityEngine;
using UnityEngine.UI;// ������ ���� ����
using UnityEngine.SceneManagement; // ������ ����
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
    {    // ���ӿ����� �ƴ� ����
        if (!isGameover)
        {
            // �����ð� ����
            surviveTime += Time.deltaTime;
            // ������ �����Ⱓ�� timetext ������Ʈ�� �̿��� ǥ��
            timeText.text = "Time : " + (int)surviveTime;

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                // ������ �ε�
                SceneManager.LoadScene("SampleScene");
            }
        }

    }
     public void EndGame()
    {
        // ������¸� ���ӿ������·� ��ȯ
        isGameover = true;
        // ���ӿ��� �׽�Ʈ��  ������Ʈ�� Ȱ��(�ڵ�� ����: ��ũ��Ʈ set Ŭ��)
        GameOverText.SetActive(true);

        // ����Ʈ Ÿ��Ű�� ����� ���������� �ְ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);

        }

        recordText.text = "Best Time : " + (int)bestTime;
    }

}
