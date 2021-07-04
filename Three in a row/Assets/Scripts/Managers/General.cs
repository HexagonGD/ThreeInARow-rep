using System;
using UnityEngine;

namespace ThreeInARow.Managers
{
    public class General
    {
        private readonly GameResources _resources;

        private static General _instance;
        public static General Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new General();
                }
                return _instance;
            }
        }

        public GameResources GameResources => _resources;

        private General()
        {
            _resources = Resources.Load<GameResources>("GameResources");
            if (_resources == null)
                throw new Exception("GeneralResources is not found");
        }
    }
}