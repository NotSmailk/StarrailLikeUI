using System.Threading.Tasks;

public interface IGameMenuPanel
{
    public bool Enabled { get; }
    public void Init();
    public void ShowPanelForce(bool show);
    public Task ShowPanel(bool show, float duration);
}
