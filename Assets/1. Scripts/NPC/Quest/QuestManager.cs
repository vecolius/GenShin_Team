using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CanvasGameManager;

public class QuestManager : MonoBehaviour
{
    Dictionary<int, string[]> questData;

    private void Awake()
    {
        questData = new Dictionary<int, string[]>();
        QuestData();
    }

    void QuestData()
    {
        questData.Add(1, new string[] { "Ʃ�丮��(���� ����)�� �ִ� ���ӽ� ã�ư���" });     
        questData.Add(2, new string[] { "���ʿ� �ִ� ���ƽ� ã�ư���" });       
        questData.Add(3, new string[] { "���� ���������� �ִ� ���̷��� ��� �� ���Ͽ������� ���ɱ�" });       
        questData.Add(4, new string[] { "���� �Ʒ� �˷��� ã�ư���" });       
        questData.Add(5, new string[] { "������ ã�ư���" });       
        questData.Add(6, new string[] { "���� �����ؼ� ���� ���� �� ���ʾƷ� �������� �̵� �� ���" });       
        questData.Add(7, new string[] { "���� �Ա� ���� �� �η��� ã�ư���" });       
        questData.Add(8, new string[] { "�������� �� ��ũ ���" });       
        questData.Add(9, new string[] { "���� �Ա� �Ʒ� �ȳ� ã�ư���" });       
        questData.Add(10, new string[] { "�������� �� ��ũ����Ʈ ���" });       
        questData.Add(11, new string[] { "���� ã�ư���" }); 
        questData.Add(12, new string[] { "�����Ա� ���� ���� ������ ���� �ϼ� ã�ư���" });
        questData.Add(13, new string[] { "�� ã�ư���" });
        questData.Add(14, new string[] { "To Be Continued......" });

    }

    public string GetQuest(int questid, int questIndex)
    {
        return questData[questid][questIndex];
    }
}

