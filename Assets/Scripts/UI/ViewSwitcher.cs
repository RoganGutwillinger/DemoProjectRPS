using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ViewSwitcher {
  private View currentView;

  public ViewSwitcher(View startingView) {
    // By default, start with smooth fade in on starting view
    this.currentView = startingView;
    this.currentView.ViewAlpha = 0f;
    this.currentView.gameObject.SetActive(true);
    this.currentView.GetShowTween();
  }

  public void SwitchToView(View nextView, Action loadingCallback, float delay = 0f) {
    Sequence sequence = DOTween.Sequence();

    // Delay before transition, if specified
    if (delay != 0f) {
      sequence.AppendInterval(delay);
    }

    // Smooth fade out on current view
    sequence.Append(this.currentView.GetHideTween());

    // Enable next view, ensuring it starts with 0 alpha
    sequence.AppendCallback(() => {
      this.currentView.gameObject.SetActive(false);
      this.currentView = nextView;
      nextView.ViewAlpha = 0f;
      nextView.gameObject.SetActive(true);
    });
    
    // Loading callback, if specified
    if (loadingCallback != null) {
      sequence.AppendCallback(loadingCallback.Invoke);
    }

    // Smooth fade in on current view
    sequence.Append(nextView.GetShowTween());
    
    sequence.Play();
  }
}
