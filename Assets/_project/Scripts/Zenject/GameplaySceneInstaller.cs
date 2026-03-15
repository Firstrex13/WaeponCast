using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private Player _player;

    public override void InstallBindings()
    {
        Player player = Container.InstantiatePrefabForComponent<Player>(_player);
        Container.Bind<Player>().FromInstance(player);
        Container.Bind<FloatingJoystick>().FromInstance(_floatingJoystick);
    }
}
