﻿namespace Library
{
    public class Kong : IItem
    {
        public bool IsAddable(Player player, AbstractVessels vasselToAdd)
        {
            if (vasselToAdd.Items.Count == 0 && vasselToAdd.Large() < 4)
            {
                return true;
            }
            return false;
        }
    }
}
