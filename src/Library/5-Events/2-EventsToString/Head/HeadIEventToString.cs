﻿
// S -  SRP: Esta clase tiene como responsabilidad realizar un evento.

// O -  OCP: Esta clase es un ejemplo del uso de OCP, se implementa la interface IEvent pero no se
//      modifica el codigo existente para agregar un evento.

// L -  LSP: Esta clase es un subtipo de IEvent.

// I -  ISP: No se utiliza.

// D -  DIP: Godzilla depende de AbstractTable, una abstraccion, y GodzillaAttack que no es una.

//      Expert: No aplica.

//      Polymorphism: El metodo DoEvent es polimorfico a todos los IEvent.

//      Creator: Esta clase usa al patron para crear instancias de GodzillaAttack, ya que las usa de manera cercana.


namespace Library
{
    public class HeadIEventToString : AbstractIEventToString
    {
        public HeadIEventToString()
        :base(new GodzillaToString())
        {
        }
        public override string ToString(IEvent catastrophe, string lang)
        {
            return this.SendNext(catastrophe, lang);
        }
    }
}