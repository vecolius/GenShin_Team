using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("��ȭ �ؽ�Ʈ")]
    public TextMeshProUGUI talkText;
    public GameObject scanObject;

    public void Action()
    {
        talkText.text = "�̰��� �̸���" + scanObject.name + "�̶�� �Ѵ�.";
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
