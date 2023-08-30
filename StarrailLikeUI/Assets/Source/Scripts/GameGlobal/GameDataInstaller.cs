using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameDataInstaller", menuName = "Installers/GameDataInstaller")]
public class GameDataInstaller : ScriptableObjectInstaller<GameDataInstaller>
{
    [field: SerializeField] private LevelsData _levelsData;
    [field: SerializeField] private AvatarsData _avatarsData;
    [field: SerializeField] private SquadData _squadData;

    public override void InstallBindings()
    {
        BindScriptableObjects();
    }

    private void BindScriptableObjects()
    {
        Container.Bind<AvatarsData>().FromScriptableObject(_avatarsData).AsSingle().Lazy();
        Container.Bind<LevelsData>().FromScriptableObject(_levelsData).AsSingle().Lazy();
        Container.Bind<SquadData>().FromScriptableObject(_squadData).AsSingle().Lazy();
    }
}