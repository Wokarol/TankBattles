using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class MinMaxTest
    {
        [Test]
        public void MinMax_Inside_Positive() {
            var value = new Wokarol.MinMax(10, 15);
            Assert.AreEqual(true, value.IsInside(12));
        }
        [Test]
        public void MinMax_Inside_Zero_Positive() {
            var value = new Wokarol.MinMax(0, 15);
            Assert.AreEqual(true, value.IsInside(12));
        }
        [Test]
        public void MinMax_Inside_Negative() {
            var value = new Wokarol.MinMax(-15, -10);
            Assert.AreEqual(true, value.IsInside(-12));
        }
        [Test]
        public void MinMax_Inside_Zero_Negative() {
            var value = new Wokarol.MinMax(-15, 0);
            Assert.AreEqual(true, value.IsInside(-12));
        }

        [Test]
        public void MinMax_Outside_Positive() {
            var value = new Wokarol.MinMax(10, 15);
            Assert.AreEqual(true, value.IsOutside(20));
        }
        [Test]
        public void MinMax_Outside_Zero_Positive() {
            var value = new Wokarol.MinMax(0, 15);
            Assert.AreEqual(true, value.IsOutside(20));
        }
        [Test]
        public void MinMax_Outside_Negative() {
            var value = new Wokarol.MinMax(-10, -15);
            Assert.AreEqual(true, value.IsOutside(-20));
        }
        [Test]
        public void MinMax_Outside_Zero_Negative() {
            var value = new Wokarol.MinMax(-15, 0);
            Assert.AreEqual(true, value.IsOutside(-20));
        }
    } 
}
