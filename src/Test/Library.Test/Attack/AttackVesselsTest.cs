using System.Collections.Generic;
using NUnit.Framework;

namespace Library.Test
{
    public class AttackVesselsTest
    {
        // Tablero.
        private Table _tab;
        private TableToString _tableToString;
        // Vessels.
        private Battleship _battleship;
        private Submarine _submarine;
        private HeavyCruiser _heavyCruiser;
        private Puntoon _puntoon;
        // Items.
        private Armor _armor;
        private SateliteLock _sateliteLock;
        private AntiaircraftMissile _anticraftMissile;
        private Kong _kong;
        private Hackers _hackers;
        // Attacks.
        private MissileAttack _missile;
        private LoadAttack _load;

        [SetUp]
        public void Setup()
        {
            this._tab = new Table();
            this._tableToString = new TableToString();

            this._battleship = new Battleship();
            this._submarine = new Submarine();
            this._heavyCruiser = new HeavyCruiser();
            this._puntoon = new Puntoon();

            this._sateliteLock = new SateliteLock();
            this._armor = new Armor();
            this._anticraftMissile = new AntiaircraftMissile();
            this._kong = new Kong();
            this._hackers = new Hackers();

            this._missile = new MissileAttack();
            this._load = new LoadAttack();
        }

        // Missile.
        [Test]
        public void MissileDoesNotAttackUnderWaterVessel()
        {
            // Arrange.
            this._tab.AddVessel(1, 1, this._submarine, true);
            // Act.
            this._tab.AttackAt(1, 1, this._missile);
            // Assert.
            Assert.AreEqual(1, this._submarine.State[0]);
        }
        [Test]
        public void MissileAttackNormalVessel()
        {
            // Arrange.
            this._tab.AddVessel(1, 1, this._battleship, true);
            // Act.
            this._tab.AttackAt(1, 1, this._missile);
            // Assert.
            Assert.AreEqual(0, this._battleship.State[0]);
        }
        [Test]
        public void ArmorAvoidMissileAttack()
        {
            // Arrange.
            this._tab.AddVessel(1, 1, this._battleship, true);
            _battleship.AddItem(0, _armor, _tab, new ArmorValidator());
            // Assert.
            Assert.Throws<Library.ArmorAttackException>(() => this._tab.AttackAt(1, 1, this._missile));
        }
        [Test]
        public void ArmorInOtherPositionDoesNotAvoidMissileAttack()
        {
            // Arrange.
            this._tab.AddVessel(1, 1, this._battleship, true);
            _battleship.AddItem(4, _armor, _tab, new ArmorValidator());
            // Assert.
            Assert.Throws<Library.ArmorAttackException>(() => this._tab.AttackAt(1, 1, this._missile));
        }
        [Test]
        public void AntiaircraftAvoidMissileAttack()
        {
            // Arrange.
            this._tab.AddVessel(1, 1, this._battleship, true);
            _battleship.AddItem(0, _anticraftMissile, _tab, new AntiaircraftMissileValidator());
            // Assert.
            Assert.Throws<Library.AntiaircraftMissileException>(() => this._tab.AttackAt(1, 1, this._missile));
        }
        [Test]
        public void SateliteLockAvoidMissileAttack()
        {
            // Arrange.
            this._tab.AddVessel(1, 1, this._battleship, true);
            _battleship.AddItem(0, _sateliteLock, _tab, new SateliteLockValidator());
            // Assert.
            try
            {
                this._tab.AttackAt(1, 1, this._missile);
            }
            catch (SateliteLockAttackException)
            {
                Assert.AreEqual(1, this._battleship.State[0]);
            }
        }
        [Test]
        public void SateliteLockAvoidMissileAttackAndDoesRandomAttackAfter()
        {
            // Arrange.
            this._tab.AddVessel(1, 1, this._battleship, true);
            _battleship.AddItem(0, _sateliteLock, _tab, new SateliteLockValidator());
            string tablero = _tableToString.ToString(_tab);
            // Assert.
            try
            {
                this._tab.AttackAt(1, 1, this._missile);
            }
            catch (SateliteLockAttackException)
            {
                Assert.AreNotEqual(_tableToString.ToString(_tab), tablero);
            }
        }
        [Test]
        public void KongDoNotAvoidMissileAttack()
        {
            // Arrange.
            this._tab.AddVessel(1, 1, this._battleship, true);
            _battleship.AddItem(0, _kong, _tab, new KongValidator());
            // Act.
            this._tab.AttackAt(1, 1, this._missile);
            // Assert.
            Assert.AreEqual(0, this._battleship.State[0]);
        }
        [Test]
        public void HackersDoNotAvoidMissileAttack()
        {
            // Arrange.
            this._tab.AddVessel(1, 1, this._puntoon, true);
            _puntoon.AddItem(0, _hackers, _tab, new HackersValidator());
            // Act.
            this._tab.AttackAt(1, 1, this._missile);
            // Assert.
            Assert.AreEqual(0, this._puntoon.State[0]);
        }
        // Load.
        [Test]
        public void OnlyOnePartIsDead()
        {
            // Arrange.
            this._tab.AddVessel(1, 1, this._battleship, true);
            // Act.
            this._tab.AttackAt(1, 1, this._load);
            // Assert.
            Assert.True(_tab.IsOrWasAVessel(1, 1));
        }
        [Test]
        public void VesselLiveAfterLoadAttackIsAlive()
        {
            //Arrange.
            this._tab.AddVessel(1, 1, this._heavyCruiser, true);
            // Act.
            this._tab.AttackAt(1, 1, this._load);
            // Assert.
            Assert.AreEqual(1, this._heavyCruiser.State[0]);
        }
        [Test]
        public void SubmarineDoesNotLiveAfterLoadAttack()
        {
            // Arrange.
            this._tab.AddVessel(1, 1, this._submarine, true);
            // Act.
            this._tab.AttackAt(1, 1, this._load);
            // Assert.
            Assert.AreEqual(0, this._submarine.State[0]);
        }
        [Test]
        public void SubmarineIsSafeWithArmor()
        {
            // Arrange.
            this._tab.AddVessel(1, 1, this._submarine, true);
            this._submarine.AddItem(0, _armor, _tab, new ArmorValidator());
            // Assert.
            Assert.Throws<Library.ArmorAttackException>(() => this._tab.AttackAt(1, 1, this._load));
        }
        [Test]
        public void AntiaircraftDoNotAvoidLoadAttack()
        {
            // Arrange.
            this._tab.AddVessel(1, 1, this._submarine, true);
            _submarine.AddItem(0, _anticraftMissile, _tab, new AntiaircraftMissileValidator());
            // Act.
            this._tab.AttackAt(1, 1, this._load);
            // Assert.
            Assert.AreEqual(0, this._submarine.State[0]);
        }
        [Test]
        public void SateliteLockAvoidLoadAttack()
        {
            // Arrange.
            this._tab.AddVessel(1, 1, this._submarine, true);
            _submarine.AddItem(0, _sateliteLock, _tab, new SateliteLockValidator());
            // Assert.
            try
            {
                this._tab.AttackAt(1, 1, this._load);
            }
            catch (SateliteLockAttackException)
            {
                Assert.AreEqual(1, this._submarine.State[0]);
            }
        }
        [Test]
        public void SateliteLockAvoidLoadAttackAndDoesRandomAttackAfter()
        {
            // Arrange.
            this._tab.AddVessel(1, 1, this._submarine, true);
            _submarine.AddItem(0, _sateliteLock, _tab, new SateliteLockValidator());
            string tablero = _tableToString.ToString(_tab);
            // Assert.
            try
            {
                this._tab.AttackAt(1, 1, this._load);
            }
            catch (SateliteLockAttackException)
            {
                Assert.AreNotEqual(_tableToString.ToString(_tab), tablero);
            }
        }
        [Test]
        public void KongDoNotAvoidLoadAttack()
        {
            // Arrange.
            this._tab.AddVessel(1, 1, this._submarine, true);
            _submarine.AddItem(0, _kong, _tab, new KongValidator());
            // Act.
            this._tab.AttackAt(1, 1, this._load);
            // Assert.
            Assert.AreEqual(0, this._submarine.State[0]);
        }
        [Test]
        public void HackersDoNotAvoidLoadAttack()
        {
            // Arrange.
            this._tab.AddVessel(1, 1, this._puntoon, true);
            _puntoon.AddItem(0, _hackers, _tab, new HackersValidator());
            // Act.
            this._tab.AttackAt(1, 1, this._load);
            // Assert.
            Assert.AreEqual(0, this._puntoon.State[0]);
        }
    }
}