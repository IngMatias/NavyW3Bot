﻿using System.Collections.Generic;
using System;

namespace Library
{
    public class Hurricane : IEvent
    {
        public void DoEvent(List<AbstractTable> participants)
        {
            // Dependencias.
            AbstractAttacker hurricane = new HurricaneAttack();
            
            Random random = new Random();
            int radio = 3;
            int lengthX = participants[0].XLength();
            int lengthY = participants[0].YLength();
            int randomX = random.Next(radio, lengthX - radio);
            int randomY = random.Next(radio, lengthY - radio);
            foreach (Table table in participants)
            {
                for (int y = 0; y < lengthY; y++)
                {
                    table.AttackAt(randomX, y, hurricane);
                }
                for (int x = 0; x < lengthX; x++)
                {
                    table.AttackAt(x, randomY, hurricane);
                }
            }
        }
    }
}