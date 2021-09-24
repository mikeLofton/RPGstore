using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace RPGstore
{
    class Shop
    {
        private int _gold;
        private Item[] _inventory;

        public Shop (Item[] items)
        {
            _gold = 100;
            _inventory = new Item[3];
            _inventory = items;
        }

        public bool Sell(Player player, int itemIndex)
        {
            Item itemForSale = _inventory[itemIndex];

            if (player.Buy(itemForSale))
            {
                _gold += itemForSale.Cost;
                return true;
            }

            return false;
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
    }
}
