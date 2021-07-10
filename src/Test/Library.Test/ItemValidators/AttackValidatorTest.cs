using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Library.Test
{
    public class ItemValidatorTest
    {
        // Validators.
        private IItemValidator _anticraft;
        private IItemValidator _armor;
        private IItemValidator _hackers;
        private IItemValidator _kong;
        private IItemValidator _sateliteLock;

        // Vessels.
        private AbstractVessel _battleShip;
        private AbstractVessel _heavyCruiser;
        private AbstractVessel _puntoon;
        private AbstractVessel _submarine;
        private AbstractVessel _frigate;

        // Table
        private AbstractTable _tab;


        [SetUp]
        public void Setup()
        {
            this._anticraft = new AntiaircraftMissileValidator();
            this._armor = new ArmorValidator();
            this._hackers = new HackersValidator();
            this._kong = new KongValidator();
            this._sateliteLock = new SateliteLockValidator();

            this._battleShip = new Battleship();
            this._heavyCruiser = new HeavyCruiser();
            this._puntoon = new Puntoon();
            this._submarine = new Submarine();
            this._frigate = new Frigate();

            this._tab = new Table();
        }

        // AntiAircraft.
        [Test]
        public void AddableAnticraft()
        {
            // Assert.
            Assert.IsTrue(this._anticraft.IsAddable(1, _battleShip, this._tab));
        }

        [Test]
        public void AnticraftPositionOutOfIndexBigNumber()
        {
            // Assert.
            Assert.Throws<System.ArgumentOutOfRangeException>(() => this._anticraft.IsAddable(10, _battleShip, this._tab));
        }

        [Test]
        public void AnticraftPositionOutOfIndexNegativeNumber()
        {
            // Assert.
            Assert.Throws<System.ArgumentOutOfRangeException>(() => this._anticraft.IsAddable(-10, _battleShip, this._tab));
        }

        [Test]
        public void AnticraftOcupedPosition()
        {
            // Arrange.
            _battleShip.AddItem(1, new Armor(), _tab, _armor);
            // Assert.
            Assert.Throws<Library.NoEmptyPositionException>(() => this._anticraft.IsAddable(1, _battleShip, this._tab));
        }

        [Test]
        public void AnticraftItemAlreadyInVessel()
        {
            // Arrange.
            _battleShip.AddItem(1, new AntiaircraftMissile(), _tab, _anticraft);
            // Assert.
            Assert.Throws<Library.NoRepetitiveItemException>(() => this._anticraft.IsAddable(10, _battleShip, this._tab));
        }

        [Test]
        public void AnticraftTableParameterEqualsNull()
        {
            Assert.IsTrue(this._anticraft.IsAddable(1, _battleShip, null));
        }

        // Armor.
        [Test]
        public void AddableArmor()
        {
            Assert.IsTrue(this._armor.IsAddable(0, _battleShip, this._tab));
        }

        [Test]
        public void ArmorPositionOutOfIndexBigNumber()
        {
            // Assert.
            Assert.Throws<System.ArgumentOutOfRangeException>(() => this._armor.IsAddable(10, _battleShip, this._tab));
        }

        [Test]
        public void ArmorPositionOutOfIndexNegativeNumber()
        {
            // Assert.
            Assert.Throws<System.ArgumentOutOfRangeException>(() => this._armor.IsAddable(-10, _battleShip, this._tab));
        }

        [Test]
        public void ArmorOcupedPosition()
        {
            // Arrange.
            _battleShip.AddItem(1, new AntiaircraftMissile(), _tab, _anticraft);
            // Assert.
            Assert.Throws<Library.NoEmptyPositionException>(() => this._armor.IsAddable(1, _battleShip, this._tab));
        }

        [Test]
        public void ArmorTableParameterEqualsNull()
        {
            Assert.IsTrue(this._armor.IsAddable(1, _battleShip, null));
        }

        // Hackers.
        [Test]
        public void AddableHackers()
        {
            Assert.IsTrue(this._hackers.IsAddable(0, _puntoon, this._tab));
        }

        [Test]
        public void HackerPositionOutOfIndexBigNumber()
        {
            // Assert.
            Assert.Throws<System.ArgumentOutOfRangeException>(() => this._hackers.IsAddable(10, _puntoon, this._tab));
        }

        [Test]
        public void HackerPositionOutOfIndexNegativeNumber()
        {
            // Assert.
            Assert.Throws<System.ArgumentOutOfRangeException>(() => this._hackers.IsAddable(-10, _puntoon, this._tab));
        }

        [Test]
        public void HackerOcupedPosition()
        {
            // Arrange.
            _puntoon.AddItem(0, new Armor(), _tab, _armor);
            // Assert.
            Assert.Throws<Library.NoEmptyPositionException>(() => this._hackers.IsAddable(0, _puntoon, this._tab));
        }

        [Test]
        public void HackerTableParameterEqualsNull()
        {
            Assert.IsTrue(this._hackers.IsAddable(0, _puntoon, null));
        }

        [Test]
        public void HackerOnlyAcceptPuntoonBattleShip()
        {
            Assert.Throws<Library.WrongVesselException>(() => this._hackers.IsAddable(0, _battleShip, this._tab));
        }

        [Test]
        public void HackerOnlyAcceptPuntoonSubmarine()
        {
            Assert.Throws<Library.WrongVesselException>(() => this._hackers.IsAddable(0, _submarine, this._tab));
        }

        [Test]
        public void HackerOnlyAcceptPuntoonHeavyCruiser()
        {
            Assert.Throws<Library.WrongVesselException>(() => this._hackers.IsAddable(0, _heavyCruiser, this._tab));
        }

        [Test]
        public void HackerOnlyAcceptPuntoonFrigate()
        {
            Assert.Throws<Library.WrongVesselException>(() => this._hackers.IsAddable(0, _frigate, this._tab));
        }

        // Kong.
        [Test]
        public void AddableKong()
        {
            Assert.IsTrue(this._kong.IsAddable(0, _battleShip, this._tab));
        }
        [Test]
        public void KongPositionDoesNotMatterBigNumber()
        {
            // Assert.
            Assert.True(this._kong.IsAddable(100000, _battleShip, this._tab));
        }

        [Test]
        public void KongPositionDoesNotMatterNegativeNumber()
        {
            // Assert.
            Assert.True(this._kong.IsAddable(-100000, _battleShip, this._tab));
        }

        [Test]
        public void KongOcupedVessel()
        {
            // Arrange.
            _battleShip.AddItem(0, new Armor(), _tab, _armor);
            // Assert.
            Assert.Throws<Library.NeededEmptyVesselException>(() => this._kong.IsAddable(0, _battleShip, this._tab));
        }

        [Test]
        public void KongTableParameterEqualsNull()
        {
            Assert.IsTrue(this._kong.IsAddable(1, _battleShip, null));
        }

        [Test]
        public void OnlyIsAddableIfVesselIsBigEnough()
        {
            Assert.Throws<Library.TooShortVesselException>(() => this._kong.IsAddable(0, _puntoon, this._tab));
        }

        // SateliteLock.
        [Test]
        public void AddableSatelite()
        {
            Assert.IsTrue(this._sateliteLock.IsAddable(0, _battleShip, this._tab));
        }

        [Test]
        public void SateliteLockPositionOutOfIndexBigNumber()
        {
            // Assert.
            Assert.Throws<System.ArgumentOutOfRangeException>(() => this._sateliteLock.IsAddable(100000, _battleShip, this._tab));
        }

        [Test]
        public void SateliteLockPositionOutOfIndexNegativeNumber()
        {
            // Assert.
            Assert.Throws<System.ArgumentOutOfRangeException>(() => this._sateliteLock.IsAddable(-100000, _battleShip, this._tab));
        }

        [Test]
        public void SateliteLockOcupedPosition()
        {
            // Arrange.
            _battleShip.AddItem(1, new AntiaircraftMissile(), _tab, _anticraft);
            // Assert.
            Assert.Throws<Library.NoEmptyPositionException>(() => this._sateliteLock.IsAddable(1, _battleShip, this._tab));
        }

        [Test]
        public void SateliteLockAlreadyUsed()
        {
            // Arrange.
            _battleShip.AddItem(1, new SateliteLock(), _tab, _sateliteLock);
            _tab.AddVessel(2, 2, _battleShip, true);
            // Assert.
            Assert.Throws<Library.NoRepetitiveItemException>(() => this._sateliteLock.IsAddable(1, _battleShip, this._tab));
        }

        [Test]
        public void SateliteLockTableParameterEqualsNull()
        {
            Assert.Throws<System.NullReferenceException>(() => this._sateliteLock.IsAddable(1, _battleShip, null));
        }

        [Test]
        public void SateliteLockReceiveEmptyTable()
        {
            Assert.True(this._sateliteLock.IsAddable(1, _battleShip, this._tab));
        }
    }
}