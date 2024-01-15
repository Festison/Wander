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
        questData.Add(1, new string[] { "튜토리얼(작은 마을)에 있는 제임스 찾아가기" });     
        questData.Add(2, new string[] { "북쪽에 있는 리아스 찾아가기" });       
        questData.Add(3, new string[] { "묘지 스테이지에 있는 스켈레톤 토벌 후 리니에르에게 말걸기" });       
        questData.Add(4, new string[] { "우측 아래 알렉스 찾아가기" });       
        questData.Add(5, new string[] { "미하일 찾아가기" });       
        questData.Add(6, new string[] { "우측 직진해서 워프 진입 후 왼쪽아래 산적워프 이동 및 토벌" });       
        questData.Add(7, new string[] { "던전 입구 좌측 위 로렌스 찾아가기" });       
        questData.Add(8, new string[] { "스테이지 속 오크 토벌" });       
        questData.Add(9, new string[] { "던전 입구 아래 안나 찾아가기" });       
        questData.Add(10, new string[] { "스테이지 속 다크나이트 토벌" });       
        questData.Add(11, new string[] { "아이 찾아가기" }); 
        questData.Add(12, new string[] { "던전입구 우측 리월 워프를 통해 일성 찾아가기" });
        questData.Add(13, new string[] { "란 찾아가기" });
        questData.Add(14, new string[] { "To Be Continued......" });

    }

    public string GetQuest(int questid, int questIndex)
    {
        return questData[questid][questIndex];
    }
}

