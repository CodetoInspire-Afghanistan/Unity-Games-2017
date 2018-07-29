using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
/// <summary>
/// Group all user interface elements together
/// </summary>
[Serializable]
public class UI  {
	[Header("Text")]
	public Text gemText;
	public Text sodierText;
	public Text timerText;
	public Text magicBottleText;
	public Text livesText;
	public GameObject GameOverPanel;
	public GameObject LevelCompletePanel;
	public Text totalGemText;
	public Text totalsodierText;
	public Text totalMagicBottleText;
	public Image heart1;
	public Image heart2;
	public Image heart3;
	public Sprite emptyHeart;
	public Sprite fullHeart;
	public GameObject pausePanel;
	public Button SoundOff;
	public Sprite img_SoundOff;
	public Sprite img_SoundOn;



}
