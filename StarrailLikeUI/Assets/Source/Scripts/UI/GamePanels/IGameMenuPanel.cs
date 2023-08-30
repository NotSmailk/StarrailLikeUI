using System.Threading.Tasks;

public interface IGameMenuPanel
{
    public void Init();
    public void ShowPanelForce(bool show);
    public Task ShowPanel(bool show, float duration);
}
