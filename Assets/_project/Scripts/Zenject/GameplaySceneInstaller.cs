using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private Player _player;

    [Inject] private IProgressService _playerProgress;

    public override void InstallBindings()
    {     
        Container.Bind<FloatingJoystick>().FromInstance(_floatingJoystick);
        Player player = Container.InstantiatePrefabForComponent<Player>(_player);
        Container.Bind<Player>().FromInstance(player);

        player.InitializePlayer(_playerProgress);
    }
}
