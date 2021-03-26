using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Library;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestLog
    {
        private Log _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new Log("file.txt");
            
        }

        [Test]
        public void ctor_LogDoorLocked()
        {
            int Id = 0;
            string filepath = Directory.GetCurrentDirectory();
            _uut.LogDoorLocked(Id);
            string[] lines= File.ReadAllLines(filepath+@"\file.txt");
            

            String Text = lines[lines.Length - 1];
            Assert.That(Text, Is.EqualTo(DateTime.Now + ": Skab låst med RFID: 0"));

        }
        [Test]
        public void ctor_LogDoorUnlocked() 
        {
            int Id = 0;
            string filepath = Directory.GetCurrentDirectory();
            _uut.LogDoorUnlocked(Id);
            string[] lines = File.ReadAllLines(filepath + @"\file.txt");


            String Text = lines[lines.Length - 1];
            Assert.That(Text, Is.EqualTo(DateTime.Now + ": Skab låst op med RFID: 0"));
        }
    }
}
