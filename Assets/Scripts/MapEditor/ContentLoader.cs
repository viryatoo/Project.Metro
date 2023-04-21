using MapEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VContainer;
using VContainer.Unity;
using UnityEngine;

namespace MapEditor
{
    public class ContentLoader
    {
        IObjectResolver container;
        LifetimeScope scope;
        MapEditorContentProvider contentProvider;
        public ContentLoader(LifetimeScope curentScope, IObjectResolver cont, MapEditorContentProvider provider)
        {
            scope = curentScope;
            container = cont;
            contentProvider = provider;
        }

        public UiEditor LoadUI()
        {
            UiEditor ui = UnityEngine.Object.Instantiate(contentProvider.uiEditor);
            container.InjectGameObject(ui.gameObject);
            //var instantScope = scope.CreateChild(builder => { builder.RegisterComponent(ui); });
            //return instantScope.Container;
            return ui;
        }
        public MapBorderView LoadBorder()
        {
            return container.Instantiate(contentProvider.borderView);
        }
    }
}
