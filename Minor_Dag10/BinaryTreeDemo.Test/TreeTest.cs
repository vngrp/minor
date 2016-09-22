﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTreeDemo.Test
{
    [TestClass]
    public class TreeTest
    {
        [TestMethod]
        public void ANewlyPlantedTreeDoesNotHaveBranchesAndLeavesYet()
        {
            // Arrange
            Tree<int> tree = Tree<int>.Create();

            // Act
            int amount = tree.Count;

            // Assert
            Assert.AreEqual(0, amount);
        }

        [TestMethod]
        public void ANewlyPlantedTreeDoesNotHaveDepthYet()
        {
            // Arrange
            Tree<int> tree = Tree<int>.Create();

            // Act
            int depth = tree.Depth;

            // Assert
            Assert.AreEqual(0, depth);
        }

        [TestMethod]
        public void AddingAValueToTheTreeIncreasesAmountOfBranchesAndLeaves()
        {
            // Arrange
            Tree<int> tree = Tree<int>.Create();

            // Act
            //              []
            tree = tree.Add(10);

            // Assert
            Assert.AreEqual(1, tree.Count);
            Assert.AreEqual(1, tree.Depth);
        }

        [TestMethod]
        public void AddingOneSmallerAndOneBigger()
        {
            // Arrange
            Tree<int> tree = Tree<int>.Create();

            // Act
            //              []
            //      []              []
            tree = tree.Add(10);
            tree = tree.Add(11);
            tree = tree.Add(9);

            // Assert
            Assert.AreEqual(3, tree.Count);
            Assert.AreEqual(2, tree.Depth);
        }

        [TestMethod]
        public void AddingOneSmallerAndThreeBigger()
        {
            // Arrange
            Tree<int> tree = Tree<int>.Create();

            // Act
            //              []
            //                      []
            //                  []      []
            tree = tree.Add(10);
            tree = tree.Add(12);
            tree = tree.Add(11);
            tree = tree.Add(13);

            // Assert
            Assert.AreEqual(4, tree.Count);
            Assert.AreEqual(3, tree.Depth);
        }

        [TestMethod]
        public void AddingFourSmaller()
        {
            // Arrange
            Tree<int> tree = Tree<int>.Create();

            // Act
            //              []
            //          []
            //      []      
            //  []
            tree = tree.Add(10);
            tree = tree.Add(9);
            tree = tree.Add(8);
            tree = tree.Add(7);

            // Assert
            Assert.AreEqual(4, tree.Count);
            Assert.AreEqual(4, tree.Depth);
        }

        [TestMethod]
        public void NicelyDecoratedChristmasTree()
        {
            // Arrange
            Tree<int> tree = Tree<int>.Create();

            // Act
            //                  []
            //          []              []
            //      []      []      []      []  
            //    []  []  []  []  []  []  []  []
            tree = tree.Add(160);

            tree = tree.Add(80);
            tree = tree.Add(240);

            tree = tree.Add(40);
            tree = tree.Add(120);
            tree = tree.Add(200);
            tree = tree.Add(280);

            tree = tree.Add(20);
            tree = tree.Add(60);
            tree = tree.Add(100);
            tree = tree.Add(140);
            tree = tree.Add(180);
            tree = tree.Add(220);
            tree = tree.Add(260);
            tree = tree.Add(300);

            // Assert
            Assert.AreEqual(15, tree.Count);
            Assert.AreEqual(4, tree.Depth);
        }

        [TestMethod]
        public void TreeContainsItem()
        {
            // Arrange
            Tree<int> tree = Tree<int>.Create();

            // Act
            tree = tree.Add(10);
            tree = tree.Add(12);
            tree = tree.Add(11);
            tree = tree.Add(13);

            bool containsItem = tree.Contains(11);

            // Assert
            Assert.IsTrue(containsItem);
        }

        [TestMethod]
        public void TreeDoesNotContainItem()
        {
            // Arrange
            Tree<int> tree = Tree<int>.Create();

            // Act
            tree = tree.Add(10);
            tree = tree.Add(12);
            tree = tree.Add(11);
            tree = tree.Add(13);

            bool containsItem = tree.Contains(14);

            // Assert
            Assert.IsFalse(containsItem);
        }

        [TestMethod]
        public void TreeCanFindItemUsingIndexer()
        {
            // Arrange
            Tree<int> tree = Tree<int>.Create();

            // Act
            //              [10]
            //                       [12]
            //                  [11]      [13]
            tree = tree.Add(10);
            tree = tree.Add(12);
            tree = tree.Add(11);
            tree = tree.Add(13);

            int foundItem = tree.Find(12);

            // Assert
            Assert.AreEqual(12, foundItem);
        }

        [TestMethod]
        public void TreeThrowsExceptionWhenItemNotFound()
        {
            // Arrange
            Tree<int> tree = Tree<int>.Create();

            // Act
            //              [10]
            //                       [12]
            //                  [11]      [13]
            tree = tree.Add(10);
            tree = tree.Add(12);
            tree = tree.Add(11);
            tree = tree.Add(13);

            Action exception = () => tree.Find(34);

            // Assert
            Assert.ThrowsException<ItemNotFoundException>(exception);
        }

        [TestMethod]
        public void AnItemCanBeFoundUsingIndexer()
        {
            // Arrange
            Tree<int> tree = Tree<int>.Create();

            // Act
            //              [10]
            //                       [12]
            //                  [11]      [13]
            tree = tree.Add(10);
            tree = tree.Add(12);
            tree = tree.Add(11);
            tree = tree.Add(13);

            int firstItem = tree[0];
            int secondItem = tree[1];
            int thirdItem = tree[2];

            // Assert
            Assert.AreEqual(10, firstItem);
            Assert.AreEqual(11, secondItem);
            Assert.AreEqual(12, thirdItem);
        }

        [TestMethod]
        public void UsingTheIndexerWithAnIndexOutOfRangeThrowsAnException()
        {
            // Arrange
            Tree<int> tree = Tree<int>.Create();

            // Act
            //              [10]
            //                       [12]
            //                  [11]      [13]
            tree = tree.Add(10);
            tree = tree.Add(12);
            tree = tree.Add(11);
            tree = tree.Add(13);

            // Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => tree[34]);
            Assert.ThrowsException<IndexOutOfRangeException>(() => tree[-1]);
        }

        [TestMethod]
        public void TheTreeIsEnumerable()
        {
            // Arrange
            Tree<int> tree = Tree<int>.Create();

            tree = tree.Add(10);
            tree = tree.Add(12);
            tree = tree.Add(11);
            tree = tree.Add(13);

            // Act
            int sum = 0;
            int amount = 0;

            foreach (int node in tree)
            {
                sum += node;
                amount++;
            }

            // Assert
            Assert.AreEqual(46, sum);
            Assert.AreEqual(4, amount);
        }

        [TestMethod]
        public void EmptyListIsReturnedByDefault()
        {
            // Arrange
            NameQueryBuilder queryBuilder = new NameQueryBuilder();

            // Act
            IEnumerable<string> names = queryBuilder.ShorterThan(4).Without('Q').Build();

            // Assert
            Assert.AreEqual(0, names.Count());
        }

        [TestMethod]
        public void AllShortNamesAreReturned()
        {
            // Arrange
            NameQueryBuilder queryBuilder = new NameQueryBuilder();
            IEnumerable<string> names = new List<string>() { "Pim", "Rob", "Wesley" };
            IEnumerable<string> expected = new List<string>() { "Pim", "Rob" };

            // Act
            queryBuilder.AddNames(names);
            IEnumerable<string> namesQuery = queryBuilder.ShorterThan(4).Without('Q').Build();

            // Assert
            CollectionAssert.AreEqual(expected.ToList(), namesQuery.ToList());
        }

        [TestMethod]
        public void AllShortNamesWithoutAnRAreReturned()
        {
            // Arrange
            NameQueryBuilder queryBuilder = new NameQueryBuilder();
            IEnumerable<string> names = new List<string>() { "Pim", "Rob", "Wesley" };
            IEnumerable<string> expected = new List<string>() { "Pim" };

            // Act
            queryBuilder.AddNames(names);
            IEnumerable<string> namesQuery = queryBuilder.ShorterThan(4).Without('R').Build();

            // Assert
            CollectionAssert.AreEqual(expected.ToList(), namesQuery.ToList());
        }

        [TestMethod]
        public void AllShortNamesWithoutAnRAreReturnedInAlphabeticalOrder()
        {
            // Arrange
            NameQueryBuilder queryBuilder = new NameQueryBuilder();
            IEnumerable<string> names = new List<string>() { "Pim", "Rob", "Max", "Wesley" };
            IEnumerable<string> expected = new List<string>() { "Max", "Pim" };

            // Act
            queryBuilder.AddNames(names);
            IEnumerable<string> namesQuery = queryBuilder.ShorterThan(4).Without('R').Build();

            // Assert
            CollectionAssert.AreEqual(expected.ToList(), namesQuery.ToList());
        }
    }
}
