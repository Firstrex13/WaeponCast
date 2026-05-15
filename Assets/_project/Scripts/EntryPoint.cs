using System.Collections;
using UnityEngine;
using YG;
using YG.Insides;
using Zenject;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private SceneSwicher _sceneSwicher;

    private WaitForSeconds delay;

    public IProgressService Progress {  get; private set; }

    private void Start()
    {
        StartCoroutine(BootStartScene());
    }

    private IEnumerator BootStartScene()
    {
        while(YG2.isSDKEnabled == false)
        {
            yield return null;
        }

        GameSaver saver = new GameSaver();

        Progress.SetProgress(saver.LoadGame());
        _sceneSwicher.SwichScene(0);
    }

    [Inject]
    public void Construct(IProgressService progressService)
    {
        Progress = progressService;
    }
}
