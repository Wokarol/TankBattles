using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class NewTestScript
    {
        // A Test behaves as an ordinary method
        [Test]
        public void NewTestScriptSimplePasses()
        {
            // Use the Assert class to test conditions
            Wokarol.MinMax minMax = new Wokarol.MinMax(20, 30);
            Assert.IsTrue(minMax.IsInside(25));
        }
    }
}
