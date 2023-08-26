using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour {
  // Main game views
  [SerializeField] private MenuView menuView;
  [SerializeField] private GameView gameView;
  [SerializeField] private GameOverView gameOverView;
  private ViewSwitcher viewSwitcher;

  // Game logic, used to resolve each round
  private GameLogic gameLogic;

  // Player models
  private Player player;
  private Opponent opponent;
  
  // Parameters/settings for the current game
  public GameParameters Parameters { get; set; }

  #region View Control Methods

  // The following methods control the view switcher and transition to the specified view

  public void SwitchToGame() {
    this.viewSwitcher.SwitchToView(this.gameView, this.StartGame);
  }

  public void SwitchToMenu() {
    this.viewSwitcher.SwitchToView(this.menuView, null);
  }

  public void SwitchToGameOver() {
    this.viewSwitcher.SwitchToView(this.gameOverView, null, 1f);
  }

  #endregion

  #region Game Flow Methods

  // The following methods drive each game and round

  public void StartGame() {
    // Initialize logic and player models
    this.gameLogic = new GameLogic();
    this.player = new Player(this.Parameters.PlayerHealth);
    this.opponent = new Opponent(this.Parameters.PlayerHealth);

    // Initialize view
    this.gameView.Initialize(this.player, this.opponent);
    this.gameView.GameMoveView.OnGameMoveSelected.AddListener(this.StartRound);
  }

  private void StartRound(GameMove selectedMove) {
    // Ensure the player cannot interact with options while round resolves
    this.gameView.GameMoveView.ButtonsEnabled = false;

    // Set selected moves for the round
    this.player.SelectedGameMove = selectedMove;
    this.opponent.SelectRandomGameMove();

    // Resolve the round and play animation
    this.gameLogic.ResolveRound(this.player, this.opponent);
    this.gameView.PlayGameAnimation(this.OnRoundEnd);
  }

  private void OnRoundEnd() {
    // Check for game over; if not, re-enable user input
    if (this.player.Health.CurrentHealth == 0) {
      this.gameOverView.ResultText = "You Lose!";
      this.SwitchToGameOver();
    } else if (this.opponent.Health.CurrentHealth == 0) {
      this.gameOverView.ResultText = "You Win!";
      this.SwitchToGameOver();
    } else {
      this.gameView.GameMoveView.ButtonsEnabled = true;
    }
  }

  #endregion

  private void Start() {
    // Game view will be re-initialized every game based on game parameters,
    // Menu and Game Over views only need to be initialized once
    this.menuView.Initialize(this);
    this.gameOverView.Initialize(this);

    // Start in main menu, disable all other views
    this.gameView.gameObject.SetActive(false);
    this.gameOverView.gameObject.SetActive(false);
    this.viewSwitcher = new ViewSwitcher(this.menuView);
  }

  // Parameters/settings for each game
  // NOTE: The struct is a bit excessive for a single int value, but it was implemented in case future settings are added
  public struct GameParameters {
    public int PlayerHealth;

    public GameParameters(int playerHealth) {
      this.PlayerHealth = playerHealth;
    }
  }
}
