public class ProgressService : IProgressService
{
    public PlayerProgress Progress { get; set; }

    public PlayerProgress GetProgress()
    {
        return Progress;
    }

    public void SetProgress(PlayerProgress playerProgress)
    {
        Progress = playerProgress;
    }
}
