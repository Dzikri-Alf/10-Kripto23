using System;

namespace MyApplication
{
  class Vigenere
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Enter Plaintext:");
      string word = Console.ReadLine();
      string key1 = "LENOVO", result_e = "", result_d = "";
      char[] myword = word.ToCharArray();
      char[] temp = word.ToCharArray();
      char[] key_temp = key1.ToCharArray();
      char[] alphabet = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
      int i = 0;
      string new_one = "";
      Console.WriteLine("Plaintext : " + word);
      Console.WriteLine("Key : " + key1);
      foreach(char ch in word)
      {
      	if(i > (key1.Length - 1))
        {
        	i = 0;
        }
      	new_one += key_temp[i];
        i = i + 1;
      }
      key1 = new_one;
      Console.WriteLine("Full Key : " + key1);
      //Encryption Cipher
      i = 0;
      foreach (char ch in key1)
        {
            int index = ((int)ch % 32) + ((int)temp[i] % 32) - 1;
            int encrypt = ((index) % 26 + 26) % 26;
            temp[i] = alphabet[encrypt];
            
            result_e += Char.ToString(temp[i]); 
            i = i + 1;
        }
        Console.WriteLine("Hasil Enkripsi : " + result_e);
      //Decryption
        i = 0;
      foreach (char ch in key1)
        {
            int index = ((int)temp[i] % 32) - ((int)ch % 32) - 1;
            int encrypt = ((index) % 26 + 26) % 26;
            temp[i] = alphabet[encrypt];
            
            result_d += Char.ToString(temp[i]); 
            i = i + 1;
        }
        Console.WriteLine("Hasil Dekripsi : " + result_d);
    }
  }
}
