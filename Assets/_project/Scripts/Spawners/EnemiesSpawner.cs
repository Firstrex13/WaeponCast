using System.Collections;
using UnityEngine;
using Zenject;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private Dragon _dragon;
    [SerializeField] private Player _player;
    [SerializeField] private Transform _spawnPosition;

    [Inject]
    public void Construct(Player player)
    {
        _player = player;
    }
    private void Start()
    {
        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        WaitForSeconds delay = new WaitForSeconds(3);

        while (enabled)
        {
            Dragon dragon = Instantiate(_dragon, _spawnPosition.position, Quaternion.identity, transform);
            AIEnemy ai = dragon.GetComponent<AIEnemy>();
            ai.Initialize(_player);
            yield return delay;
        }
    }
}
