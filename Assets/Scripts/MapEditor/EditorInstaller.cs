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
            builder.Register<IMapPanelModel,MainPanelModel>(Lifetime.Singleton);
            builder.Register<BlockProvider>(Lifetime.Singleton);
            builder.Register<Map>(Lifetime.Singleton);
            builder.Register<CameraMovement>(Lifetime.Singleton);
            builder.Register<ISaveSevice,JsonSL>(Lifetime.Singleton);
            builder.RegisterEntryPoint<EditorLoop>(Lifetime.Singleton);
        }

    }
}