using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameMoveView : MonoBehaviour {
  // Buttons for each game move
  [SerializeField] private Button rockButton;
  [SerializeField] private Button paperButton;
  [SerializeField] private Button scissorsButton;
  [SerializeField] private CanvasGroup canvasGroup;

  // Event used to signal the player has chosen a move
  public UnityEvent<GameMove> OnGameMoveSelected;

  public bool ButtonsEnabled {
    get { return this.buttonsEnabled; }
    set {
      this.rockButton.enabled = value;
      this.paperButton.enabled = value;
      this.scissorsButton.enabled = value;
      this.buttonsEnabled = value;
      this.canvasGroup.alpha = value ? 1f : 0.3f;
    }
  }

  private bool buttonsEnabled;

  public void Initialize() {
    // Setup button callbacks
    this.OnGameMoveSelected.RemoveAllListeners();
    this.rockButton.onClick.RemoveAllListeners();
    this.rockButton.onClick.AddListener(() => this.OnGameMoveSelected?.Invoke(GameMove.Rock));
    this.paperButton.onClick.RemoveAllListeners();
    this.paperButton.onClick.AddListener(() => this.OnGameMoveSelected?.Invoke(GameMove.Paper));
    this.scissorsButton.onClick.RemoveAllListeners();
    this.scissorsButton.onClick.AddListener(() => this.OnGameMoveSelected?.Invoke(GameMove.Scissors));

    this.ButtonsEnabled = true;
  }
}
