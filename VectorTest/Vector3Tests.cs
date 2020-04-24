using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RayTracer;

namespace VectorTest
{
    [TestClass]
    public class Vector3Tests
    {
        [TestMethod]
        public void Constructor()
        {
            var v1 = new Vector3(1.1, 2.2, 3.3);
            Assert.AreEqual(1.1, v1.X);
            Assert.AreEqual(2.2, v1.Y);
            Assert.AreEqual(3.3, v1.Z);
        }

        [TestMethod]
        public void Equality()
        {
            var v1 = new Vector3(1.1, 2.2, 3.3);
            var v2 = new Vector3(1.1, 2.2, 3.3);
            var v3 = new Vector3(3.3, 2.2, 1.1);
            Assert.AreEqual(v1,v2);
            Assert.AreNotEqual(v1, v3);
        }

        [TestMethod]
        public void Length()
        {
            var v1 = new Vector3(1, 2, 3);
            Assert.AreEqual(3.74, Math.Round(v1.Length(),2));
        }

        [TestMethod]
        public void Normalised()
        {
            var v1 = new Vector3(1, 2, 3);
            var vr = v1.Normalized();
            Assert.AreEqual(1, vr.Length());
            Assert.AreEqual(0.27, Math.Round(vr.X, 2));
            Assert.AreEqual(0.53, Math.Round(vr.Y, 2));
            Assert.AreEqual(0.80, Math.Round(vr.Z, 2));
        }

        [TestMethod]
        public void ScalarMultiply()
        {
            var v1 = new Vector3(1, 2, 3);
            var vr = v1.ScalarMultiply(4);
            Assert.AreEqual(4, vr.X);
            Assert.AreEqual(8, vr.Y);
            Assert.AreEqual(12, vr.Z);
        }

        [TestMethod]
        public void Plus1()
        {
            var v1 = new Vector3(1, 2, 3);
            var v2 = new Vector3(7, 0, 6);
            var vr = v1.Plus(v2);
            Assert.AreEqual(8, vr.X);
            Assert.AreEqual(2, vr.Y);
            Assert.AreEqual(9, vr.Z);
        }


        [TestMethod]
        public void Plus2()
        {
            var v1 = new Vector3(1, 2, 3);
            var v2 = new Vector3(7, 0, 6);
            var vr = v2.Plus(v1);
            Assert.AreEqual(8, vr.X);
            Assert.AreEqual(2, vr.Y);
            Assert.AreEqual(9, vr.Z);
        }

        [TestMethod]
        public void Minus1()
        {
            var v1 = new Vector3(1, 2, 3);
            var v2 = new Vector3(7, 0, 6);
            var vr = v2.Minus(v1);
            Assert.AreEqual(6, vr.X);
            Assert.AreEqual(-2, vr.Y);
            Assert.AreEqual(3, vr.Z);
        }


        [TestMethod]
        public void Minus2()
        {
            var v1 = new Vector3(1, 2, 3);
            var v2 = new Vector3(7, 0, 6);
            var vr = v1.Minus(v2);
            Assert.AreEqual(-6, vr.X);
            Assert.AreEqual(2, vr.Y);
            Assert.AreEqual(-3, vr.Z);
        }

        [TestMethod]
        public void DotProduct()
        {
            var v1 = new Vector3(1, 2, 3);
            var v2 = new Vector3(7, 0, 6);
            double dp = v2.DotProduct(v1);
            Assert.AreEqual(25, dp);
        }

        [TestMethod]
        public void CrossProduct1()
        {
            var v1 = new Vector3(2,3,4);
            var v2 = new Vector3(5,6,7);
            var vr = v1.CrossProduct(v2);
            Assert.AreEqual(-3, vr.X);
            Assert.AreEqual(6, vr.Y);
            Assert.AreEqual(-3, vr.Z);
        }

        [TestMethod]
        public void CrossProduct2()
        {
            var v1 = new Vector3(2, 3, 4);
            var v2 = new Vector3(5, 6, 7);
            var vr = v2.CrossProduct(v1);
            Assert.AreEqual(3, vr.X);
            Assert.AreEqual(-6, vr.Y);
            Assert.AreEqual(3, vr.Z);
        }

        #region Operators
        [TestMethod]
        public void MultiplyOperatorScalar1()
        {
            var v1 = new Vector3(1, 2, 3);
            var vr = v1 * 4;
            Assert.AreEqual(4, vr.X);
            Assert.AreEqual(8, vr.Y);
            Assert.AreEqual(12, vr.Z);
        }

        [TestMethod]
        public void MultiplyOperatorScalar2()
        {
            var v1 = new Vector3(1, 2, 3);
            var vr = 4 * v1;
            Assert.AreEqual(4, vr.X);
            Assert.AreEqual(8, vr.Y);
            Assert.AreEqual(12, vr.Z);
        }

        [TestMethod]
        public void PlusOperator1()
        {
            var v1 = new Vector3(1, 2, 3);
            var v2 = new Vector3(7, 0, 6);
            var vr = v1 + v2;
            Assert.AreEqual(8, vr.X);
            Assert.AreEqual(2, vr.Y);
            Assert.AreEqual(9, vr.Z);
        }

        [TestMethod]
        public void PlusOperator2()
        {
            var v1 = new Vector3(1, 2, 3);
            var v2 = new Vector3(7, 0, 6);
            var vr = v2 + v1;
            Assert.AreEqual(8, vr.X);
            Assert.AreEqual(2, vr.Y);
            Assert.AreEqual(9, vr.Z);
        }

        [TestMethod]
        public void MinusOperator1()
        {
            var v1 = new Vector3(1, 2, 3);
            var v2 = new Vector3(7, 0, 6);
            var vr = v2 - v1;
            Assert.AreEqual(6, vr.X);
            Assert.AreEqual(-2, vr.Y);
            Assert.AreEqual(3, vr.Z);
        }

        [TestMethod]
        public void MinusOperator2()
        {
            var v1 = new Vector3(1, 2, 3);
            var v2 = new Vector3(7, 0, 6);
            var vr = v1 - v2;
            Assert.AreEqual(-6, vr.X);
            Assert.AreEqual(2, vr.Y);
            Assert.AreEqual(-3, vr.Z);
        }
        #endregion
    }
}
