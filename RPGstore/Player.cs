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
        
        public int Gold
        {
            get { return _gold; }
        }

        public Player()
        {
            _gold = 500;
            _inventory = new Item[0];
        }

        public void Buy(Item item)
        {
            _gold -= item.Cost;

            Item[] playerInventory = new Item[_inventory.Length + 1];

            for (int i = 0; i < _inventory.Length; i++)
                playerInventory[i] = _inventory[i];

            playerInventory[_inventory.Length] = item;

            _inventory = playerInventory;
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
            return false;
        }
    }
}
