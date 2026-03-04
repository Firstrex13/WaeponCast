using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerPresenter _presenter;

    public void Initialize(PlayerPresenter playerPresenter)
    {
        _presenter = playerPresenter;
    }

    private void Start()
    {
        _presenter.Enable();
    }

    private void OnDestroy()
    {
        _presenter.Disable();
    }
}
