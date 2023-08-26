using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverView : View {
  // UI component references
  [SerializeField] private TextMeshProUGUI resultText;
  [SerializeField] private Button playAgainButton;
  [SerializeField] private Button menuButton;

  // Message displaying win/lose state
  public string ResultText {
    get { return this.resultText.text; }
    set { this.resultText.text = value; }
  }

  public void Initialize(GameManager gameManager) {
    // Setup button listeners and callbacks
    this.playAgainButton.onClick.AddListener(() => gameManager.SwitchToGame());
    this.menuButton.onClick.AddListener(() => gameManager.SwitchToMenu());
  }
}
