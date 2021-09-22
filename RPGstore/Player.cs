using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace RPGstore
{
    class Player
    {
        private int _gold;
        private Item[] _inventory;

        public Player(int inventoryIndex)
        {
            _gold = 500;
            _inventory = new Item[inventoryIndex];
        }

        public void Buy(Item item)
        {
            if (_gold >= item.Cost)
            {
                


            }
        }

        public string[] GetItemNames()
        {
            string[] itemNames = new string[_inventory.Length];

            for (int i = 0; i < _inventory.Length; i++)
            {
                itemNames[i] = _inventory[i].Name;
            }

            return itemNames;
        }

        public void Save(StreamWriter writer)
        {

        }

        public bool Load(StreamReader reader)
        {

        }
    }
}
