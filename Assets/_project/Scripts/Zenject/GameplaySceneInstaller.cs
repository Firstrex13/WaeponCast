using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _manaText;
    [SerializeField] private Mana _mana;

    [Inject] private IProgressService _playerProgress;

    public override void InstallBindings()
    {     
        Container.Bind<InputReader>().FromInstance(_inputReader);
        Player player = Container.InstantiatePrefabForComponent<Player>(_player);
        Container.Bind<Player>().FromInstance(player);

        player.InitializePlayer(_playerProgress, _slider, _manaText, _mana);
    }
}
