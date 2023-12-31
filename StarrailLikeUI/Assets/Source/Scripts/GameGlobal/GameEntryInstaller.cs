using UnityEngine;
using Zenject;

public class GameEntryInstaller : MonoInstaller
{
    [field: SerializeField] private string _username = "Default";
    [field: SerializeField] private GameSettings _settings;
    [field: SerializeField] private GameCharacters _characters;
    [field: SerializeField] private GameStateMachine _gameBehaviour;
    [field: SerializeField] private GameCamera _camera;
    [field: SerializeField] private GameUI _gameUI;

    public override void InstallBindings()
    {
        BindSettings();

        BindStateMachine();

        BindProviders();

        BindCharacters();

        BindCamera();

        BindUI();
    }

    private void BindProviders()
    {
        var userProvider = Container.Instantiate<UserProvider>(new object[] { _username });
        Container.Bind<UserProvider>().FromInstance(userProvider).AsSingle().NonLazy();

        var deviceInfo = Container.Instantiate<DeviceInfoProvider>();
        Container.Bind<DeviceInfoProvider>().FromInstance(deviceInfo).AsSingle().NonLazy();

        var storeProvider = Container.Instantiate<StoresDataProvider>();
        Container.Bind<StoresDataProvider>().FromInstance(storeProvider).AsSingle().NonLazy();

        var spinsProvider = Container.Instantiate<SpinsDataProvider>();
        Container.Bind<SpinsDataProvider>().FromInstance(spinsProvider).AsSingle().NonLazy();

        var characterProvider = Container.Instantiate<CharactersDataProvider>();
        Container.Bind<CharactersDataProvider>().FromInstance(characterProvider).AsSingle().NonLazy();

        var itemDataCollection = Container.Instantiate<ItemCollectionProvider>();
        Container.Bind<ItemCollectionProvider>().FromInstance(itemDataCollection).AsSingle().NonLazy();

        var friendsProvider = new FriendsDataProvider(userProvider);
        Container.Bind<FriendsDataProvider>().FromInstance(friendsProvider).AsSingle().NonLazy();

        var assignmentsProvider = new AssignmentsDataProvider();
        Container.Bind<AssignmentsDataProvider>().FromInstance(assignmentsProvider).AsSingle().NonLazy();

        var soundProvider = new SoundDataProvider();
        Container.Bind<SoundDataProvider>().FromInstance(soundProvider).AsSingle().NonLazy();
    }

    private void BindSettings()
    {
        Container.Bind<GameSettings>().FromInstance(_settings).AsSingle().NonLazy();
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