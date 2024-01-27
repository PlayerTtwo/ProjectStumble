using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class XToStart : MonoBehaviour
{
    public TMP_Text readyPlayer1;
    public TMP_Text readyPlayer2;
    public string newText = "New Text";

    public Animator _Player1Anim;
    public Animator _Player2Anim;
    public Animator _FadeOutTxtAnim;
    public Image _ReadyP1Img;
    public Image _ReadyP2Img;
    public Sprite _Joinedimg;

    public Image _ReadyP1BtnImg;
    public Image _ReadyP2BtnImg;
    public Sprite _JoinedBtnimg;

    public GameObject P1WhiteBg;
    public GameObject P2WhiteBg;

    private void OnEnable()
    {
        LevelManager.Instance.OnPlayerJoined += LevelManager_OnPlayerJoined;
    }

    private void OnDisable()
    {
        LevelManager.Instance.OnPlayerJoined -= LevelManager_OnPlayerJoined;
    }

    private void LevelManager_OnPlayerJoined(int playerIndex)
    {
        if (playerIndex == 1)
        {
            readyPlayer1.text = newText;
            _ReadyP1Img.sprite = _Joinedimg;
            _ReadyP1BtnImg.sprite = _JoinedBtnimg;
            P1WhiteBg.SetActive(true);
        }
        else if (playerIndex == 2)
        {
            readyPlayer2.text = newText;
            _ReadyP2Img.sprite = _Joinedimg;

            _ReadyP2BtnImg.sprite = _JoinedBtnimg;
            P2WhiteBg.SetActive(true);
        }
    }

    void Update()
    {
        if (readyPlayer1.text == newText && readyPlayer2.text == newText)
        {
            _FadeOutTxtAnim.Play("FadeOutGameName");
            StartCoroutine(Example());
        }
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(1.5f);
        _Player1Anim.Play("CardAnimationDown");
        _Player2Anim.Play("CardAnimationUp");
    }
}
    
