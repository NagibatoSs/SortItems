using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SortItems
{
    public interface IStorable
    {
        public bool Save();
        public bool Load();
    }
}
