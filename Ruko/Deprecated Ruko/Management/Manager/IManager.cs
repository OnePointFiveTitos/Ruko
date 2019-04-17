namespace Management
{
    public interface IManager
    {
        string AppName { get; }
        LoginViewModel<IManager> Login { get; }
    }
}