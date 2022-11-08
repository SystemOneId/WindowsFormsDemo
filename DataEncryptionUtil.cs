using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDemo
{
    public partial class DataEncryptionUtil : Form
    {
        private const string _passPhrase = "Bh7Y0FlLgha15Ho8L9YBDemoflngu3gx0L33nLYgZhjSOBvYsSBbrPppqpyA";
        private const string _initVector = "KKmgff9qykTngGG1";
        private const string _hashAlgorithm = "SHA1";
        private const int _passwordIterations = 2;
        private const int _keySize = 256;

        public DataEncryptionUtil()
        {
            InitializeComponent();
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            var openFileTextFile = new OpenFileDialog();
            openFileTextFile.Filter = "Text Files|*.txt";
            openFileTextFile.InitialDirectory = Environment.CurrentDirectory;
            openFileTextFile.ShowDialog();
            var fileContents = File.ReadAllText(openFileTextFile.FileName).Split("\r\n".ToCharArray());
            var encryptedData = "";
            for (var i = 0; i < fileContents.Length; i++)
            {
                var line = fileContents[i].Trim();
                var salt = CreateSalt();
                var encryptedRecord = Encrypt(line, salt);
                if (encryptedData.Length > 0)
                {
                    encryptedData += "\r\n";
                }
                encryptedData += encryptedRecord + "\t" + salt + "\r\n";
                var progressPercent = Convert.ToInt32((Convert.ToDecimal(i) / fileContents.Length) * 100M);
                progressBarEncrypt.Value = progressPercent;
                labelEncryptProgress.Text = i.ToString() + " (" + progressPercent.ToString() + "%)";
            }
            var saveTextFile = new SaveFileDialog();
            saveTextFile.Filter = "Text File|*.txt";
            saveTextFile.ShowDialog();
            var encryptedFile = File.CreateText(saveTextFile.FileName);
            encryptedFile.Write(encryptedData);
            encryptedFile.Flush();
            encryptedFile.Close();
        }

        public string Encrypt(string plainText, string saltValue)
        {
            var initVectorBytes = Encoding.ASCII.GetBytes(_initVector);
            var saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var password = new PasswordDeriveBytes(_passPhrase, saltValueBytes, _hashAlgorithm, _passwordIterations);
            var keyBytes = password.GetBytes(_keySize / 8);
            var symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            var cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            var cipherText = Convert.ToBase64String(cipherTextBytes);
            Thread.Sleep(50);
            return cipherText;
        }

        public string Decrypt(string cipherText, string saltValue)
        {
            if (string.IsNullOrWhiteSpace(cipherText))
            {
                return string.Empty;
            }
            var initVectorBytes = Encoding.ASCII.GetBytes(_initVector);
            var saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            var cipherTextBytes = Convert.FromBase64String(cipherText);
            var password = new PasswordDeriveBytes(_passPhrase, saltValueBytes, _hashAlgorithm, _passwordIterations);
            var keyBytes = password.GetBytes(_keySize / 8);
            var symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            var decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            var plainTextBytes = new byte[cipherTextBytes.Length];
            var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            var plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
            return plainText;
        }

        public string CreateSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[32];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
    }
}
