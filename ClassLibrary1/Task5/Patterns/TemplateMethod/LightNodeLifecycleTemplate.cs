using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task5.Patterns.TemplateMethod
{
    public abstract class LightNodeLifecycleTemplate
    {
        public string Execute(LightNode node)
        {
            BeforeCreate(node);
            BeforeInsert(node);
            BeforeRender(node);
            AfterRender(node);
            BeforeRemove(node);

            return node.OuterHTML();
        }

        protected virtual void BeforeCreate(LightNode node)
        {
            node.OnCreated();
        }

        protected virtual void BeforeInsert(LightNode node)
        {
            node.OnInserted();
        }

        protected virtual void BeforeRender(LightNode node)
        {
        }

        protected virtual void AfterRender(LightNode node)
        {
            node.OnTextRendered();
        }

        protected virtual void BeforeRemove(LightNode node)
        {
            node.OnRemoved();
        }
    }

    public sealed class DefaultLightNodeLifecycleTemplate : LightNodeLifecycleTemplate
    {
    }

}
