using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameIntro : MonoBehaviour
{
    [Header("��Ʈ�� �ؽ�Ʈ")]
    public TextMeshProUGUI introText;
    public int TextIndex = 0;
    public int TextId = 1;
    public GameObject loadingUI;

    Dictionary<int, string[]> IntroTextData;

    private void Awake()
    {
        loadingUI.SetActive(false);
        IntroTextData = new Dictionary<int, string[]>();
        IntroData();
    }

    void IntroData()
    {
        IntroTextData.Add(0, new string[] { "[�Ʒ��Ͼ� ����]�� �����Ͻ��� ��ɲ��̽� �ƹ������Լ�\r\n�� ������ �Ƿ��� ��ǰ�� ã�ƿ� �޶�� ��Ź�� �޴´�." });
        IntroTextData.Add(1, new string[] { "�ƹ����� ���� ��ǰ�� ã�� ���ƿ� �����Ͻ���\r\n�δ��� �ְ��� �� �θ���� �����ϰ� �ȴ�." });
        IntroTextData.Add(2, new string[] { "���� ���� �ڸ��� �󸶳� �ӹ��� �� �� \r\n������ �θ�԰� ���ߴٴ� ������� �����Ͻ��� ã�ƿ´�." });
        IntroTextData.Add(3, new string[] { "�θ���� ���� ������ ã�� �� �ְ� �����ְڴٴ� �׵���\r\n�ڽŵ��� ���� [ ��ī�� ]�� ������ [ �������� ]�� �Ұ��ߴ�." });
        IntroTextData.Add(4, new string[] { "ȥ�ڼ��� �ƹ��͵� �� �� ���ٴ� �� �밨�� �����Ͻ���\r\n�׵� �� �� ���� ���� ������ ���� ������ ������." });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (TextId > 4)
            {
                loadingUI.SetActive(true);
                SceneManager.LoadScene("Wander");
            }
            string questData = GetIntro(TextId, TextIndex);
            introText.text = questData;
            TextId++;
        }
    }
    public string GetIntro(int textId, int textIndex)
    {
        return IntroTextData[textId][textIndex];
    }
    public void OnClickSkip()
    {
        Debug.Log("Skip");
        loadingUI.SetActive(true);
        SceneManager.LoadScene("Wander");
    }
}
