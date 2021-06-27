
// S -  SRP: Esta clase define la fase de Eventos.

// O -  OCP: Implementando IPhase podemos permitir el agregado de nuevas fases 
//      sin la necesidad de alterar el codigo, sino mas bien simplemente agregando una nueva clase.
           
// L -  LSP: EventPhase es un subtipo de IPhase.

// I -  ISP: No se usan todas las operaciones definidas en IPriner e IReader.

// D -  DIP: Se depende solo de abstracciones.

//      Expert: Esta clase conoce los eventos por lo tanto se encarga de elegir entre ellos cual ejecutar.

//      Polymorphism: El metodo Excecute es polimorfico en todos los IPhase.

//      Creator: No se aplica.

using System;
using System.Collections.Generic;

namespace Library
{
    public class EventPhase : IPhase
    {
        // Dependencias.
        private Random random = new Random();
        private static IEvent _godzilla = new Godzilla();
        private static IEvent _hurricane = new Hurricane();
        private static IEvent _meteorShower = new MeteorShower();
        private static IEvent _volcano = new Volcano();
        private List<IEvent> _events = new List<IEvent>
        {
            _godzilla,
            _hurricane,
            _meteorShower,
            _volcano,
        };
        public List<int> Execute(AbstractTable player, List<AbstractTable> enemies, IPrinter clientP, IReader clientR)
        {
            int rnd = random.Next(0, 15);
            foreach (AbstractTable table in enemies)
            {
                if (0 <= rnd && rnd <= this._events.Count)
                {
                    this._events[rnd].DoEvent(enemies);
                }
            }
            return new List<int>();
        }
    }
}