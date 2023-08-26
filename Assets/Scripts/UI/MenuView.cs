using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuView : View {
  // UI component references
  [SerializeField] private Button playButton;
  [SerializeField] private Slider healthSlider;
  [SerializeField] private TextMeshProUGUI healthText;

  // Life count for players next round
  public int SelectedHealth {
    get { return (int)this.healthSlider.value + 2; }
  }

  public void Initialize(GameManager gameManager) {
    // Setup button listener and callback
    this.playButton.onClick.AddListener(() => {
      gameManager.Parameters = new GameManager.GameParameters(this.SelectedHealth);
      gameManager.SwitchToGame();
    });

    // Setup slider to select life count
    this.healthSlider.onValueChanged.AddListener(this.UpdateHealthText);
    this.healthSlider.value = 0;
  }

  // For now, hard-coding health values to be between 2 and 5
  public void UpdateHealthText(float value) {
    this.healthText.text = this.SelectedHealth.ToString() + " Lives";
  }
}
