using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

[Serializable]
public class ChatBoxWidget
{
    public RectTransform panel;
    public TMP_Text mainContent;
    public Image background;
    public Image character;
    public Image preHint;
    public Image nextHint;
    public Image skipHint;
    public Image closeHint;
    public Image finishHint;

    [Header("read only")]
    public bool isShow;
    public Dictionary<int, Vector3> poss=new Dictionary<int, Vector3>();

    public void Init()
    {
        poss.Add(panel.gameObject.GetInstanceID(), panel.transform.position);
        poss.Add(mainContent.gameObject.GetInstanceID(), mainContent.transform.localPosition);
        poss.Add(background.gameObject.GetInstanceID(), background.transform.localPosition);
        poss.Add(character.gameObject.GetInstanceID(), character.transform.localPosition);
        poss.Add(preHint.gameObject.GetInstanceID(), preHint.transform.localPosition);
        poss.Add(nextHint.gameObject.GetInstanceID(), nextHint.transform.localPosition);
        poss.Add(skipHint.gameObject.GetInstanceID(), skipHint.transform.localPosition);
        poss.Add(closeHint.gameObject.GetInstanceID(), closeHint.transform.localPosition);
        poss.Add(finishHint.gameObject.GetInstanceID(), finishHint.transform.localPosition);

        //set initial position
        panel.position = poss.GetValueOrDefault(panel.gameObject.GetInstanceID()) + Vector3.down * 500;
        panel.gameObject.SetActive(false);
        nextHint.gameObject.SetActive(false);
        preHint.gameObject.SetActive(false);
        finishHint.gameObject.SetActive(false);
        skipHint.gameObject.SetActive(false);
        closeHint.gameObject.SetActive(true);
    }
}

[Serializable]
public class ChatData
{
    public string character;
    public string passage;
}

[Serializable]
public class ParagraghData
{
    public int chatIndex;
    public List<ChatData> chats;

    public bool IsHead
    {
        get { return chatIndex == 0; }
    }
    public bool IsTail
    {
        get { return chatIndex == chats.Count - 1; }
    }
    public ChatData FirstChat
    {
        get 
        {
            chatIndex = 0;
            return chats[chatIndex];
        }
    }
    public ChatData NextChat
    {
        get
        {
            chatIndex++;
            if (chatIndex >= chats.Count)
            {
                chatIndex = chats.Count - 1;
            }
            return chats[chatIndex];
        }
    }
    public ChatData PreChat
    {
        get
        {
            chatIndex--;
            if (chatIndex < 0)
            {
                chatIndex = 0;
            }
            return chats[chatIndex];
        }
    }
}

/// <summary>
/// chat box
/// show main content
/// next
/// pre
/// close
/// finish
/// skip
/// shake character
/// </summary>
public class ChatBoxController : MonoBehaviour
{
    private static ChatBoxController instance;

    private void Awake()
    {
        instance = this;
    }

    public static ChatBoxController Instance
    {
        get { return instance; }
    }



    public ChatBoxWidget widget;
    public ParagraghData paragragh;
    public Action OnShow;
    public Action OnClose;
    public Action OnFinish;

    private void Start()
    {
        widget.Init();
    }

    public void Show()
    {
        //customize event
        OnShow?.Invoke();

        //move panel
        widget.panel.gameObject.SetActive(true);
        widget.panel.DOKill();
        widget.panel.DOMove(widget.poss.GetValueOrDefault(widget.panel.gameObject.GetInstanceID()), 1f).SetEase(Ease.OutBack);
    }

    public void First()
    {
        widget.mainContent.text = paragragh.FirstChat.passage;
        HighlightContent();
        UpdateShowButton();
    }

    public void Next()
    {
        widget.mainContent.text = paragragh.NextChat.passage;
        HighlightContent();
        HighlightButton(widget.nextHint.transform);
        UpdateShowButton();
    }

    public void Pre()
    {
        widget.mainContent.text = paragragh.PreChat.passage;
        HighlightContent();
        HighlightButton(widget.preHint.transform);
        UpdateShowButton();
    }

    public void Close()
    {
        HighlightButton(widget.closeHint.transform);

        //move panel
        widget.panel.DOKill();
        widget.panel.DOMove(widget.poss.GetValueOrDefault(widget.panel.gameObject.GetInstanceID()) + Vector3.down * 500, 1).SetEase(Ease.Linear).OnComplete(() =>
             {
                 widget.panel.gameObject.SetActive(false);
             });

        //customize event
        OnClose?.Invoke();
    }

    public void Finish()
    {
        HighlightButton(widget.finishHint.transform);

        //customize event
        OnFinish?.Invoke();
    }

    //-------------------------
    private void HighlightContent()
    {
        Transform t = widget.mainContent.transform;
        Vector3 pos = widget.poss.GetValueOrDefault(t.gameObject.GetInstanceID());
        t.DOKill();
        Sequence seq = DOTween.Sequence();
        seq.Append(t.DOLocalMove(pos + Vector3.up * 50, 0.15f).SetEase(Ease.InBounce));
        seq.Append(t.DOLocalMove(pos, 0.15f).SetEase(Ease.OutBounce));
    }

    private void HighlightButton(Transform t)
    {
        Vector3 pos = widget.poss.GetValueOrDefault(t.gameObject.GetInstanceID());
        t.DOKill();
        Sequence seq = DOTween.Sequence();
        seq.Append(t.DOLocalMove(pos + Vector3.down * 50, 0.15f).SetEase(Ease.InCubic));
        seq.Append(t.DOLocalMove(pos, 0.15f).SetEase(Ease.OutCubic));
    }

    private void UpdateShowButton()
    {
        if (paragragh.IsHead)
        {
            widget.closeHint.gameObject.SetActive(true);
            widget.finishHint.gameObject.SetActive(false);
            widget.nextHint.gameObject.SetActive(true);
            widget.preHint.gameObject.SetActive(false);
        }
        else if(paragragh.IsTail)
        {
            widget.closeHint.gameObject.SetActive(true);
            widget.finishHint.gameObject.SetActive(true);
            widget.nextHint.gameObject.SetActive(false);
            widget.preHint.gameObject.SetActive(true);
        }
        else
        {
            widget.closeHint.gameObject.SetActive(true);
            widget.finishHint.gameObject.SetActive(false);
            widget.nextHint.gameObject.SetActive(true);
            widget.preHint.gameObject.SetActive(true);
        }
    }
}
