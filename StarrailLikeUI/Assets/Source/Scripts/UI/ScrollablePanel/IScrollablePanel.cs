using System.Threading.Tasks;

public interface IScrollablePanel
{
    Task ShowPanel(bool show, PanelAnimationType type);
    void ShowPanel(bool show);
    void DestroyPanel();
}
