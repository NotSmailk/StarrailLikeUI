using UnityEngine;
using Zenject;

public class GameEntryInstaller : MonoInstaller
{
    [field: SerializeField] private string _username = "Default";
    [field: SerializeField] private GameCharacters _characters;
    [field: SerializeField] private GameStateMachine _gameBehaviour;
    [field: SerializeField] private GameCamera _camera;
    [field: SerializeField] private GameUI _gameUI;

    public override void InstallBindings()
    {
        BindStateMachine();

        BindProviders();

        BindCharacters();

        BindCamera();

        BindUI();
    }

    private void BindProviders()
    {
        var userProvider = Container.Instantiate<UserProvider>(new object[] { _username });
        var deviceInfo = Container.Instantiate<DeviceInfoProvider>();

        Container.Bind<UserProvider>().FromInstance(userProvider).AsSingle().NonLazy();
        Container.Bind<DeviceInfoProvider>().FromInstance(deviceInfo).AsSingle().NonLazy();
    }

    private void BindCharacters()
    {
        Container.Bind<GameCharacters>().FromInstance(_characters).AsSingle().NonLazy();
    }

    private void BindStateMachine()
    {
        Container.Bind<GameStateMachine>().FromInstance(_gameBehaviour).AsSingle().NonLazy();
    }

    private void BindCamera()
    {
        Container.Bind<GameCamera>().FromInstance(_camera).AsSingle().NonLazy();
    }

    private void BindUI()
    {
        Container.Bind<GameUI>().FromInstance(_gameUI).AsSingle().NonLazy();
    }

    private new void Start()
    {
        base.Start();
        Init();
    }

    private void Init()
    {
        _camera.Init();
        _characters.Init();
        _gameUI.Init();
        _gameBehaviour.Init();
    }

    private void Update()
    {
        _gameBehaviour.GameUpdate();
    }
}