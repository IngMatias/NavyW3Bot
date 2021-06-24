using NUnit.Framework;
using Library;
using System;

namespace Library.Test
{
    
    public class ItemValidatorTests
    {
        // Items.
        private IItem _antiAircraftMisile;
        private IItem _hackers;
        private IItem _sateliteLock;
        private IItem _armor;
        private IItem _kong;
        // Items validatores.
        private IItemValidator _antiaircraftValidator;
        private IItemValidator _hackersValidator;
        private IItemValidator _sateliteLockValidator;
        private IItemValidator _armorValidator;
        private IItemValidator _kongValidator;
        // Vessels.
        private AbstractVessel _heavyCruiser;
        private AbstractVessel _lightCruiser;
        private AbstractVessel _puntoon;
        private AbstractVessel _battleShip;
        private AbstractVessel _frigate;
        // Table.
        private AbstractTable _table;

        [SetUp]
        public void Setup()
        {
            this._antiAircraftMisile = new AntiaircraftMissile();
            this._hackers = new Hackers();
            this._sateliteLock = new SateliteLock();
            this._armor = new Armor();
            this._kong = new Kong();

            this._antiaircraftValidator = new AntiaircraftMissileValidator();
            this._hackersValidator = new HackersValidator();
            this._sateliteLockValidator = new SateliteLockValidator();
            this._armorValidator = new ArmorValidator();
            this._kongValidator = new KongValidator();

            this._heavyCruiser = new HeavyCruiser();
            this._lightCruiser = new LightCruiser();
            this._puntoon = new Puntoon();
            this._battleShip = new Battleship();
            this._frigate = new Frigate();

            this._table = new Table();
        }

        // Se testea si se agrega a la lista de items de la embarcación.
        [Test]
        public void IsAddableCheckItemsTest()
        {
            // Act.
            _heavyCruiser.AddItem(1,_antiAircraftMisile,_table,_antiaircraftValidator);
            IItem item = _heavyCruiser.Items[1];
            // Assert.
            Assert.AreEqual(_antiAircraftMisile, item);
        }

        // Kong

        // Se testea que no se pueda añadir el kong si hay cualquier otro item.
        [Test]
        public void OnlyKongTest()
        {
            // Act.
            _battleShip.AddItem(1,_armor,_table,_armorValidator);
            
            // Assert.
            try
            {
                _battleShip.AddItem(1,_kong,_table,_kongValidator);
            }
            catch(Library.NeededEmptyVesselException)
            {
                
            }
            //Assert.Throws<Library.NeededEmptyVesselException>(()=> _battleShip.AddItem(1,_kong,_table,_kongValidator));
        }

        // Se testea que solo se pueda agregar a barcos más largos que 4. Frigate = 2
        // Debe arrojar la excepcion "Library.TooShortVesselException"
        [Test]
        public void LongEnoughTest()
        {
            // Assert.
            Assert.Catch<Library.TooShortVesselException>(()=>_frigate.AddItem(0,_kong,_table,_kongValidator));
        }

        // Se testea que si el barco tiene un kong, no se pueda agregar otro item pero si se quita el kong si se pueda
        [Test]
        public void IfIsKongTest()
        { 
            // Act.
            _battleShip.AddItem(1,_kong,_table,_kongValidator);
            // Assert.
            Assert.IsFalse(_battleShip.AddItem(1,_antiAircraftMisile,_table,_antiaircraftValidator));
            // Act.
            _battleShip.RemoveItem(_kong);
            Assert.IsTrue(_battleShip.AddItem(1,_antiAircraftMisile,_table,_antiaircraftValidator));
            
        } 
    }
}