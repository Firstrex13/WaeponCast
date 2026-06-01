using System.Collections;
using UnityEngine;
using YG;
using Zenject;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private SceneSwicher _sceneSwicher;

    public IProgressService Progress {  get; private set; }

    private void Start()
    {
        BootStartScene();
    }

    private void BootStartScene()
    {
        while(YG2.isSDKEnabled == false)
        {
            return;
        }

        GameSaver saver = new GameSaver();

        Progress.SetProgress(saver.LoadGame());
        _sceneSwicher.SwichScene(1);
    }

    [Inject]
    public void Construct(IProgressService progressService)
    {
        Progress = progressService;
    }
}
