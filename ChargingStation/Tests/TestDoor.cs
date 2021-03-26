using System;
using System.Collections.Generic;
using System.Text;
using Library;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestDoor
    {
        private Door _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new Door();
        }
    }
}
