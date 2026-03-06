using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SortItems
{
    public class CharactersController : MonoBehaviour
    {
        [SerializeField] GameObject _characters;
        public void Show()
        {
            //ѕоказывает только при вертикальной ориентации
            if (Screen.height > Screen.width)
            {
                _characters.SetActive(true);
            }
        }

        public void Hide()
        {
            _characters.SetActive(false);
        }

    }
}
