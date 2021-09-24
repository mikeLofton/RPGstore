﻿using System;
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
            _inventory = items;
        }

        public bool Sell(Player player, int itemIndex)
        {
            if (player.Gold >= _inventory[itemIndex].Cost)
            {
                _gold += _inventory[itemIndex].Cost;
                player.Buy(_inventory[itemIndex]);
                return true;
            }
            return false;
        }

        public string[] GetItemNames()
        {
            string[] itemNames = new string[_inventory.Length];

            for (int i = 0; i < _inventory.Length; i++)
            {
                itemNames[i] = $"{_inventory[i].Name} - {_inventory[i].Cost}g";
            }

            return itemNames;
        }
    }
}
