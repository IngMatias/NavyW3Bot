
// S -  SRP: Tiene la responsabilidad declarar un error.

// O -  OCP: Basta con heredar Exception para implementar un error.

// L -  LSP: Todas las excepciones se comportan de igual manera.

// I -  ISP: No aplica.

// D -  DIP: No aplica.

//      Expert: No aplica.

//      Polymorphism: No aplica.

//      Creator: No aplica.

using System;

namespace Library
{
    [Serializable]
    public class NoOneMissileException : VesselAttackException
    {
    }
}