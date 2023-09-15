using System;

namespace MyApplication
{
  class Shift
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Enter username:");
      string word = Console.ReadLine();
      word = word.ToUpper();
      string name = "";
      int i = 0;
      char[] alphabet = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
      int key = 7;
      int key1 = 2;
      char[] myword = word.ToCharArray();
      char[] temp = word.ToCharArray();
      Console.WriteLine("Plaintext: " + word);
      
      //Encryption
      foreach (char ch in myword)
      {
      	int index = ((int)ch % 32) - 1;
        int encrypt = ((index + key) % 26 + 26) % 26;
        temp[i] = alphabet[encrypt];
        name = name + Char.ToString(temp[i]); 
        i = i + 1;
      }
      Console.WriteLine("Encryption: " + name);
      name = "";
      i = 0;
      
      //Decryption
      foreach(char ch in temp)
      {
      	int index = ((int)ch % 32) - 1;
        int encrypt = ((index - key) % 26 + 26) % 26;
        temp[i] = alphabet[encrypt];
        name = name + Char.ToString(temp[i]); 
        i = i + 1; 
      }
      Console.WriteLine("Decryption: " + name);
      
      //Check
      if (name == word)
      {
      	Console.WriteLine("Status: Success");
      }
      else
      {
        Console.WriteLine("Status: Failed");
      }
      
    }
  }
}