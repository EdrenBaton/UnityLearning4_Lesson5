using System;
using System.Collections.Generic;

namespace Asteroids
{
    [Serializable]
    public class InspectorDictionary
    {
        public List<Items> _itemsDictionary;
    }

    [Serializable]
    public class Items
    {
        public string _key;
        public string _value;
    }
}