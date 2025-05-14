using UnityEngine;
using Zenject;

namespace Cifkor.Karpusha
{
    public class AppInstaller : MonoInstaller
    {
        [SerializeField] private Presenter _presenter;
        [SerializeField] private WeatherView _weatherView;
        [SerializeField] private DogBreedsView _breedsView;

        public override void InstallBindings()
        {
            BindView();        
        }

        private void BindView()
        {
            WeatherView weatherView = Container
                .InstantiatePrefabForComponent<WeatherView>(_weatherView);
            DogBreedsView dogBreedView = Container
                .InstantiatePrefabForComponent<DogBreedsView>(_breedsView);

            Container
                .Bind<WeatherView>()
                .FromInstance(weatherView)
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<DogBreedsView>()
                .FromInstance(dogBreedView)
                .AsSingle()
                .NonLazy();
        }
    }
}