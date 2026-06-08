using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Player _player;

    [Inject] private IProgressService _playerProgress;

    public override void InstallBindings()
    {     
        Container.Bind<InputReader>().FromInstance(_inputReader);
        Player player = Container.InstantiatePrefabForComponent<Player>(_player);
        Container.Bind<Player>().FromInstance(player);

        player.InitializePlayer(_playerProgress);
    }
}
