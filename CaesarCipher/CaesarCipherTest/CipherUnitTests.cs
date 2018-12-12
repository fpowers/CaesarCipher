using System;
using CaesarCipher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaesarCipherTest
{
    [TestClass]
    public class CipherUnitTests
    {
        [TestMethod]
        public void Encrypt_EncodesCorrectly()
        {
            string unencodedString = "abcdefghijklmnopQRSTUVwxyz123456!@#$%^";
            int offset = 2;
            string expectedEncodedString = "cdefghijklmnopqrSTUVWXyzab123456!@#$%^";
            string actualEncodedString;

            CipherEncoder encoder = new CipherEncoder();
            actualEncodedString = encoder.Encrypt(unencodedString, offset);

            Assert.AreEqual(expectedEncodedString, actualEncodedString, "Encoded strings are not equal");
        }
        
        [TestMethod]
        public void Encrypt_LargeOffset()
        {
            string unencodedString = "abcdefghijklmnopQRSTUVwxyz123456!@#$%^";
            int offset = 2602;
            string expectedEncodedString = "cdefghijklmnopqrSTUVWXyzab123456!@#$%^";
            string actualEncodedString;

            CipherEncoder encoder = new CipherEncoder();
            actualEncodedString = encoder.Encrypt(unencodedString, offset);

            Assert.AreEqual(expectedEncodedString, actualEncodedString, "Encoded strings are not equal");
        }

        [TestMethod]
        public void Encrypt_EmptyString()
        {
            string unencodedString = "";
            int offset = 2;
            string expectedEncodedString = "";
            string actualEncodedString;

            CipherEncoder encoder = new CipherEncoder();
            actualEncodedString = encoder.Encrypt(unencodedString, offset);

            Assert.AreEqual(expectedEncodedString, actualEncodedString, "Encoded strings are not equal");
        }

        [TestMethod]
        public void SwitchLetter_LowercaseLetter()
        {
            string unencodedLetter = "a";
            int offset = 1;
            string expectedEncodedLetter = "b";
            string actualEncodedLetter;

            CipherEncoder encoder = new CipherEncoder();
            actualEncodedLetter = encoder.SwitchLetter(unencodedLetter, offset);

            Assert.AreEqual(expectedEncodedLetter, actualEncodedLetter, "Switched letters are not equal");
        }

        [TestMethod]
        public void SwitchLetter_UppercaseLetter()
        {
            string unencodedLetter = "A";
            int offset = 1;
            string expectedEncodedLetter = "B";
            string actualEncodedLetter;

            CipherEncoder encoder = new CipherEncoder();
            actualEncodedLetter = encoder.SwitchLetter(unencodedLetter, offset);

            Assert.AreEqual(expectedEncodedLetter, actualEncodedLetter, "Switched letters are not equal");
        }

        [TestMethod]
        public void SwitchLetter_NonLetterSymbol()
        {
            string unencodedSymbol = "%";
            int offset = 1;
            string expectedEncodedSymbol = "%";
            string actualEncodedSymbol;

            CipherEncoder encoder = new CipherEncoder();
            actualEncodedSymbol = encoder.SwitchLetter(unencodedSymbol, offset);

            Assert.AreEqual(expectedEncodedSymbol, actualEncodedSymbol, "Switched letters are not equal");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SwitchLetter_EmptyString()
        {
            string unencodedSymbol = "";
            int offset = 1;
            string expectedEncodedSymbol = "";
            string actualEncodedSymbol;

            CipherEncoder encoder = new CipherEncoder();
            actualEncodedSymbol = encoder.SwitchLetter(unencodedSymbol, offset);

            Assert.AreEqual(expectedEncodedSymbol, actualEncodedSymbol, "Switched letters are not equal");
        }
    }
}
