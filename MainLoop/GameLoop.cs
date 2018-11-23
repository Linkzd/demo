using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainLoop
{
    public class GameLoop : BaseLoop
    {
        public void Init()
        {
            ObjectManager.Current.objectloops.ForEach(p => p.OnInit());
        }

        public override void Start()
        {
            ObjectManager.Current.objectloops.ForEach(p => p.OnStart());
            base.Start();
        }

        public override void UpDate()
        {
            ObjectManager.Current.objectloops.ForEach(p => p.OnUpdate());
            ObjectManager.Current.objectloops.ForEach(p => p.OnRender());
            base.UpDate();
        }

        public void Destory()
        {
            ObjectManager.Current.objectloops.ForEach(p => p.OnDestory());
        }
    }

    public interface IObjectloop
    {
        void OnInit();
        void OnUpdate();
        void OnStart();
        void OnRender();
        void OnDestory();
    }

    public class ObjectManager
    {
        private static ObjectManager _current;
        public static ObjectManager Current
        {
            get
            {
                if (_current == null)
                    _current = new ObjectManager();
                return _current;
            }
        }

        public List<IObjectloop> objectloops = new List<IObjectloop>();

        public void AddObject(IObjectloop objectloop)
        {
            objectloops.Add(objectloop);
        }

        public void RemoveObject(IObjectloop objectloop)
        {
            objectloops.Remove(objectloop);
        }
    }
}
