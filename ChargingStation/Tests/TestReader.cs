using System;
using System.Collections.Generic;
using System.Text;
using Library;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestReader
    {
        private RFIDReader _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new RFIDReader();
        }
    }
}
