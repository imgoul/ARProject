using System.Collections;
using System.Collections.Generic;
using Assets.Script.StrangeIoc.model.Chapters;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

public class ChapterView : View
{
    //获取所有章节信号
    public Signal getAllChaptersSignal=new Signal();
    //存放所有章节的父物体
    public GameObject chapterLayoutGroup;
    //章节按钮预制体
    public GameObject chapterPrefab;
    //章节面板
    public GameObject chapterPanel;
    private List<Chapter> chapterList = null;

    protected override void Start()
    {
        getAllChaptersSignal.Dispatch();
    }
    void Update()
    {
        if (chapterList != null)
        {
            LoadChapterSync();
            chapterList = null;
        }
    }
    /// <summary>
    /// 加载所有章节
    /// </summary>
    /// <param name="chaptersList">所有章节列表</param>
    public void OnLoadChapters(List<Chapter> chapterList)
    {
        this.chapterList = chapterList;
    }

    private void LoadChapterSync()
    {
        foreach (var chapter in chapterList)
        {
            GameObject go = Instantiate(chapterPrefab);
            go.transform.SetParent(chapterLayoutGroup.transform);
            go.transform.localScale = Vector3.one;
            go.GetComponentInChildren<Text>().text = "第" + chapter.ChapterId.ToString() + "章:" + chapter.ChapterName;
            go.name = chapter.ChapterId.ToString();
            go.AddComponent<MainButtonEvent>();
            go.GetComponent<Button>().onClick.AddListener(OnClickChapterBtn);
        }
        
    }
    /// <summary>
    /// 章节按钮点击回调函数
    /// </summary>
    public void OnClickChapterBtn()
    {
        chapterPanel.SetActive(false);
    }

}
