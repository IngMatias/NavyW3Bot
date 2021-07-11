using System.Collections.Generic;
using NUnit.Framework;

namespace Library.Test
{
    public class AttackValidatorTest
    {
        private AntiaircraftMissileAttackValidator _anticraft;
        private ArmorAttackValidator _armor;
        private HackersAttackValidator _hackers;
        private KongAttackValidator _kong;
        private SateliteLockAttackValidator _sateliteLock;

        private Table _tab;
        private AbstractAttacker _attacker;

        [SetUp]
        public void Setup()
        {
            this._anticraft = new AntiaircraftMissileAttackValidator();
            this._armor = new ArmorAttackValidator();
            this._hackers = new HackersAttackValidator();
            this._kong = new KongAttackValidator();
            this._sateliteLock = new SateliteLockAttackValidator();

            this._tab = new Table();
        }

        // AntiAircraftMissile solo debe evitar los ataques de missiles.
        [Test]
        public void AntiAircraftMissileAvoidMissile()
        {
            this._attacker = new MissileAttack();
            Assert.Throws<Library.AntiaircraftMissileException>(() =>this._anticraft.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void AntiAircraftMissileNotAvoidLoad()
        {
            this._attacker = new LoadAttack();
            Assert.IsFalse(this._anticraft.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void AntiAircraftMissileNotAvoidGodzilla()
        {
            this._attacker = new GodzillaAttack();
            Assert.IsFalse(this._anticraft.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void AntiAircraftMissileNotAvoidMeteor()
        {
            this._attacker = new MeteorAttack();
            Assert.IsFalse(this._anticraft.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void AntiAircraftMissileNotAvoidLava()
        {
            this._attacker = new LavaAttack();
            Assert.IsFalse(this._anticraft.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void AntiAircraftMissileNotAvoidHurricane()
        {
            this._attacker = new HurricaneAttack();
            Assert.IsFalse(this._anticraft.AvoidAttack(this._tab,this._attacker));
        }
        // Armor debe evadir Loads y Missils
        [Test]
        public void ArmorAvoidMissile()
        {
            this._attacker = new MissileAttack();
            Assert.Throws<Library.ArmorAttackException>(() => this._armor.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void ArmorAvoidLoad()
        {
            this._attacker = new LoadAttack();
             Assert.Throws<Library.ArmorAttackException>(() => this._armor.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void ArmorNotAvoidGodzilla()
        {
            this._attacker = new GodzillaAttack();
            Assert.IsFalse(this._armor.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void ArmorNotAvoidHurricane()
        {
            this._attacker = new HurricaneAttack();
            Assert.IsFalse(this._armor.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void ArmorNotAvoidLava()
        {
            this._attacker = new LavaAttack();
            Assert.IsFalse(this._armor.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void ArmorNotAvoidMeteor()
        {
            this._attacker = new MeteorAttack();
            Assert.IsFalse(this._armor.AvoidAttack(this._tab,this._attacker));
        }
        // Hackers no defiende ningun tipo de ataque.
        [Test]
        public void HackersNotAvoidMissile()
        {
            this._attacker = new MissileAttack();
            Assert.IsFalse(this._hackers.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void HackersNotAvoidLoad()
        {
            this._attacker = new LoadAttack();
            Assert.IsFalse(this._hackers.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void HackersNotAvoidGodzilla()
        {
            this._attacker = new GodzillaAttack();
            Assert.IsFalse(this._hackers.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void HackersNotAvoidHurricane()
        {
            this._attacker = new HurricaneAttack();
            Assert.IsFalse(this._hackers.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void HackersNotAvoidLava()
        {
            this._attacker = new LavaAttack();
            Assert.IsFalse(this._hackers.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void HackersNotAvoidMeteor()
        {
            this._attacker = new MeteorAttack();
            Assert.IsFalse(this._hackers.AvoidAttack(this._tab,this._attacker));
        }
        // Kong solo evita un ataque de Godzilla.
        [Test]
        public void KongAvoidGodzilla()
        {
            this._attacker = new GodzillaAttack();
            Assert.Throws<Library.KongAttackException>(() => this._kong.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void KongNotAvoidMissile()
        {
            this._attacker = new MissileAttack();
            Assert.IsFalse(this._kong.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void KongNotAvoidLoad()
        {
            this._attacker = new LoadAttack();
            Assert.IsFalse(this._kong.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void KongNotAvoidHurricane()
        {
            this._attacker = new HurricaneAttack();
            Assert.IsFalse(this._kong.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void KongNotAvoidLava()
        {
            this._attacker = new LavaAttack();
            Assert.IsFalse(this._kong.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void KongNotAvoidMeteor()
        {
            this._attacker = new MeteorAttack();
            Assert.IsFalse(this._kong.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void SateliteLockAvoidLoad()
        {
            this._attacker = new LoadAttack();
            Assert.Throws<Library.SateliteLockAttackException>(() => this._sateliteLock.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void SateliteLockAvoidMissile()
        {
            this._attacker = new MissileAttack();
            Assert.Throws<Library.SateliteLockAttackException>(() => this._sateliteLock.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void SateliteLockNotAvoidHurricane()
        {
            this._attacker = new HurricaneAttack();
            Assert.IsFalse(this._sateliteLock.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void SateliteLockNotAvoidLava()
        {
            this._attacker = new LavaAttack();
            Assert.IsFalse(this._sateliteLock.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void SateliteLockNotAvoidMeteor()
        {
            this._attacker = new MeteorAttack();
            Assert.IsFalse(this._sateliteLock.AvoidAttack(this._tab,this._attacker));
        }
        [Test]
        public void SateliteLockNotAvoidKong()
        {
            this._attacker = new GodzillaAttack();
            Assert.IsFalse(this._sateliteLock.AvoidAttack(this._tab,this._attacker));
        }
    }
}