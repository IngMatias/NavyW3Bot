
// S - SRP: Esta clase tiene la responsabilidad de definir el estado de un barco.

// O -  OCP: Si se aplica, para agregar una forma diferente de estado basta con implementar una nueva clase.

// L -  LSP: Cualquier clase que herede esta debe ser y es un subtipo de esta clase.

// I -  ISP: No se aplica.

// D -  DIP: Esta clase solo depende de abstracciones.

//      Expert: Esta clase conoce el estado del barco, por lo tanto se encarga de su manejo.

//      Polymorphism: No se aplica.

//      Creator: No se utiliza.

using System.Collections.Generic;
using System;

namespace Library
{
    public abstract class AbstractStateManager : AbstractItemSaver
    {
        protected int[] _state;
        public IList<int> State
        {
            get
            {
                return Array.AsReadOnly(this._state);
            }
        }
        public AbstractStateManager(int size, int health)
        : base(size)
        {
            this._state = new int[size];
            this.InitState(health);
        }
        protected void InitState(int health)
        {
            for (int i = 0; i < this._state.Length; i++)
            {
                this._state[i] = health;
            }
        }
        public bool IsAlive()
        {
            foreach (int i in State)
            {
                if (i != 0)
                {
                    return true;
                }
            }
            return false;
        }
        public virtual bool ReceiveAttackAt(AbstractAttackable table, AbstractAttacker attack)
        {
            bool isAttackable = this.IsAttackable(table, attack);
            if (isAttackable)
            {
                this._state[attack.Position] -= 1;
                if (this._state[attack.Position] == 0)
                {
                    return true;
                }
            }
            return false;
        }
        public virtual bool ReceiveDestruction(AbstractAttackable table, AbstractAttacker attack)
        {
            if (this.IsAttackable(table, attack))
            {
                this.InitState(0);
                return true;
            }
            return false;
        }
    }
}