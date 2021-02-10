// <copyright file="LogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GameLogicTests
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Media;
    using GameModel;
    using GameRepository;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// The Tests for the GameLogic.
    /// </summary>
    [TestFixture]
    public class LogicTests
    {
        private GameLogic.GameLogic logic;
        private Mock<IGameModel> model;
        private Mock<IGameRepository> repo;

        /// <summary>
        /// Setup commands before every test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.model = new Mock<IGameModel>();
            this.repo = new Mock<IGameRepository>();
            this.model.SetupAllProperties();
            this.model.Object.Enemies = new List<Enemy>();
            this.model.Object.Bullets = new List<Bullet>();
            this.model.Object.Score = 0;
            this.model.Object.Player = new Ship(0, 0, new RectangleGeometry(), 100, 100, 100, 100, 100, 100, 100);
            this.model.Object.Map = string.Empty;
            this.logic = new GameLogic.GameLogic(this.model.Object, this.repo.Object, false);
        }

        /// <summary>
        /// OneTick method moves the enemy and is deleted after leaves a game field.
        /// </summary>
        [Test]
        public void OneTick_ShouldCallMoveEnemyAndEnemyShouldGetDeleted_WhenCenterXIsLessThanZero()
        {
             // Arrange
            Enemy enemy = new Enemy(-10, 10, new RectangleGeometry(new Rect(0, 0, 100, 100)), 10, 10, 100, 10, 10, false, 100, 100, 100);

             // Act
            this.logic.OneTick();

             // Assert
            Assert.AreEqual(0, this.model.Object.Enemies.Count);
        }

        /// <summary>
        /// OneTick method moves the enemy and it is deleted after it collides with the palyer.
        /// </summary>
        [Test]
        public void OneTick_ShouldCallMoveEnemyAndScoreAndPlayerHealthShouldChange_WhenCollidesWithPlayer()
        {
             // Arrange
            Enemy enemy = new Enemy(0, 0, new RectangleGeometry(new Rect(0, 0, 50, 50)), 10, 10, 100, 10, 10, false, 100, 100, 100);
            this.model.Object.Player = new Ship(0, 0, new RectangleGeometry(new Rect(0, 0, 50, 50)), 200, 200, 100, 100, 100, 100, 100);
            this.model.Object.Enemies.Add(enemy);

             // Act
            this.logic.OneTick();

             // Assert
            Assert.AreEqual(10, this.model.Object.Score);
            Assert.AreEqual(100, this.model.Object.Player.Health);
        }

        /// <summary>
        /// OneTick method moves the enemy and it stays alive when nothing harms it.
        /// </summary>
        [Test]
        public void OneTick_ShouldCallMoveEnemyAndEnemyShouldStayAlive_WhenThereIsNoCollision()
        {
             // Arrange
            Enemy enemy = new Enemy(220, 230, new RectangleGeometry(new Rect(0, 0, 50, 50)), -10, -10, 100, 10, 10, false, 100, 100, 100);
            this.model.Object.Enemies.Add(enemy);

             // Act
            this.logic.OneTick();

             // Assert
            Assert.AreEqual(210, enemy.CenterX);
            Assert.AreEqual(220, enemy.CenterY);
        }

        /// <summary>
        /// Fire adds one bullet to the model.
        /// </summary>
        [Test]
        public void Fire_ShouldAddOneBulletToModelBullets_WhenCalled()
        {
             // Arrange

             // Act
            this.logic.Fire();

             // Assert
            Assert.AreEqual(1, this.model.Object.Bullets.Count);
        }

        /// <summary>
        /// OneTick method adds one bullet to the model when the enemy is ready to fire.
        /// </summary>
        [Test]
        public void OneTick_ShouldCallEnemyFireAndOneBulletShouldBeAddedToTheModel_WhenTheEnemyIsReadyToFire()
        {
             // Arrange
            Enemy enemy = new Enemy(220, 230, new RectangleGeometry(new Rect(0, 0, 50, 50)), -10, -10, 100, 10, 10, false, 100, 100, 100);
            enemy.CurrentChagre = 99;
            this.model.Object.Enemies.Add(enemy);

             // Act
            this.logic.OneTick();

             // Assert
            Assert.AreEqual(1, this.model.Object.Bullets.Count);
        }

        /// <summary>
        /// MovePlayer moves the player's centerx and centery appropriatly to the given Point.
        /// </summary>
        /// <param name="x">The Point's X coord.</param>
        /// <param name="y">The Point's Y coord.</param>
        /// <param name="expectedx">The expected centerX.</param>
        /// <param name="expectedy">The expected centerY.</param>
        [TestCase(0, 0, 450, 450)]
        [TestCase(0, 1000, 450, 550)]
        [TestCase(1000, 0, 550, 450)]
        [TestCase(1000, 1000, 550, 550)]
        [TestCase(500, 0, 500, 450)]
        [TestCase(500, 1000, 500, 550)]
        [TestCase(0, 500, 450, 500)]
        [TestCase(1000, 500, 550, 500)]
        public void MovePlayer_ShouldMovePlayerOneSpeedUnit_WhenThePointIsFarEnough(int x, int y, int expectedx, int expectedy)
        {
            // Arrange
            this.model.Object.Player.CenterX = 500;
            this.model.Object.Player.CenterY = 500;
            this.model.Object.Player.Speed = 50;

            // Act
            this.logic.MovePlayer(new Point(x, y));

            // Assert
            Assert.AreEqual(expectedx, this.model.Object.Player.CenterX);
            Assert.AreEqual(expectedy, this.model.Object.Player.CenterY);
        }

        /// <summary>
        /// MovePlayer does not move player's centerx and centery when a difference is too small.
        /// </summary>
        /// <param name="x">The Point's X coord.</param>
        /// <param name="y">The Point's Y coord.</param>
        [TestCase(480, 500)]
        [TestCase(480, 480)]
        [TestCase(500, 480)]
        [TestCase(520, 480)]
        [TestCase(520, 500)]
        [TestCase(520, 520)]
        [TestCase(500, 520)]
        [TestCase(480, 520)]
        public void MovePlayer_ShouldNotMovePlayer_WhenThePointIsNotFarEnough(int x, int y)
        {
            // Arrange
            this.model.Object.Player.CenterX = 500;
            this.model.Object.Player.CenterY = 500;
            this.model.Object.Player.Speed = 50;

            // Act
            this.logic.MovePlayer(new Point(x, y));

            // Assert
            Assert.AreEqual(500, this.model.Object.Player.CenterX);
            Assert.AreEqual(500, this.model.Object.Player.CenterY);
        }
    }
}