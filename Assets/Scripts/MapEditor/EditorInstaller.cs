using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapEditor.EditorStates;
using VContainer;
using VContainer.Unity;

namespace MapEditor
{
    //главный класс. здесь создаются все зависимости.
    public class EditorInstaller : LifetimeScope
    {
        [SerializeField] private MapEditorContentProvider contentProvider;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(contentProvider);
            builder.Register<ContentLoader>(Lifetime.Singleton);
            builder.Register<StateMachine>(Lifetime.Singleton);
            builder.Register<BlockFactory>(Lifetime.Singleton);
            builder.Register<MainPanelModel>(Lifetime.Singleton);
            builder.Register<BlockProvider>(Lifetime.Singleton);
            builder.RegisterComponentInNewPrefab(contentProvider.borderView, Lifetime.Singleton);
            builder.Register<Map>(Lifetime.Singleton);
            builder.Register<CameraMovement>(Lifetime.Singleton);
            builder.RegisterComponentInNewPrefab(contentProvider.uiEditor,Lifetime.Singleton);
            builder.Register<ISaveSevice,JsonSL>(Lifetime.Singleton);
            RegisterStates(builder);
            builder.RegisterEntryPoint<EditorLoop>(Lifetime.Singleton);
        }

        private void RegisterStates(IContainerBuilder builder)
        {
            builder.Register<PanelBlockSelected>(Lifetime.Singleton);
            builder.Register<WaitPlayerInputState>(Lifetime.Singleton);
        }

    }
}