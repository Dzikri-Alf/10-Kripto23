using System;

namespace MyApplication
{
  class Hill
  {
    static void Main(string[] args)
    {
      string word = "jul", name = "";
      char[] myword = word.ToCharArray();
      char[] temp = word.ToCharArray();
      char[] alphabet = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
      int one = 1, two = 2, three = 3, four = 4, five = 5, six = 6, seven = 7, eight = 8, nine = 2;
      int[,] arr1 = {
      {one, two, three},
      {four, five, six},
      {seven, eight, nine}
      };
      int[,] letter = new int[3,3];
      int i = 0;
      Console.WriteLine("Plaintext : " + word);
      
      //Encryption
      name += "Encryption : ";
      foreach (char ch in myword)
      {
      	int index = 0;
        for (int j = 0; j < 3; j++)
        {
        	index = ((int)ch % 32) - 1;
            letter[i, j] = index * arr1[i, j];
        }
        i = i + 1;
      }
      for (i = 0; i < 3; i++)
      {
      	int encrypt = ((letter[0, i] + letter[1, i] + letter[2, i]) % 26 + 26) % 26;
        temp[i] = alphabet[encrypt];
        name = name + Char.ToString(temp[i]);
      }
      
      //Decryption
      name += "\nDecryption : ";
      int det = 0;
      for(i=0;i<3;i++)
      {
      	det = det + (arr1[0,i]*(arr1[1,(i+1)%3]*arr1[2,(i+2)%3] - arr1[1,(i+2)%3]*arr1[2,(i+1)%3]));
      }
      int k = 0;
      for (int j = 1; j < 26; j++)
            if (((det % 26) * (j % 26)) % 26 == 1)
            	k = j;
      Console.Write("\nThe Determinant of the matrix is: {0} and the GCD is {1}\n\n",det, k);
      int[,] result = new int[3,3];
   	  for(i=0;i<3;i++){
      	for(int j=0;j<3;j++)
        	result[i,j] = (arr1[(i+1)%3,(j+1)%3] * arr1[(i+2)%3,(j+2)%3]) - (arr1[(i+1)%3,(j+2)%3]*arr1[(i+2)%3,(j+1)%3]);
   	  }
      for(i = 0; i < 3; i++)
      {
      	int index = 0;
        int x = 0;
      	for(int j = 0; j < 3; j++)
        {
        	index = ((int)temp[j] % 32) - 1;
            x = x + (index * result[i, j]);
        }
        int encrypt = ((x * k) % 26 + 26) % 26;
        myword[i] = alphabet[encrypt];
        name = name + Char.ToString(myword[i]);
      }
      Console.WriteLine(name);
      
      //Key 
      string pt = "FRID", ct = "PQCF";
      char[] arr_pt = pt.ToCharArray();
      char[] arr_cp = ct.ToCharArray();
      int[,] matrix_pt = new int[2,2];
      int[,] matrix_cp = new int[2,2];
      int[,] adj = new int[2,2];
      
      for(i = 0; i < 2; i++)
      {
          for(int j = 0; j < 2; j++)
          {
            int index = ((int)arr_pt[i+(j+i)] % 32) - 1;
            matrix_pt[i, j] = index;
          }
      }
      foreach(int matrix in matrix_pt)
      {
        Console.WriteLine(matrix);
      }
      for(i = 0; i < 2; i++)
      {
          for(int j = 0; j < 2; j++)
          {
            int index = ((int)arr_cp[i+(j+i)] % 32) - 1;
            matrix_cp[i, j] = index;
          }
      }
      foreach(int matrix in matrix_cp)
      {
        Console.WriteLine(matrix);
      }
      int det1 = (matrix_pt[0,0] * matrix_pt[1,1]) - (matrix_pt[0,1] * matrix_pt[1,0]);
      for (int j = 1; j < 26; j++)
            if (((det1 % 26) * (j % 26)) % 26 == 1)
            	k = j;
      Console.WriteLine(k);
      adj[0,0] = matrix_pt[1,1];
      adj[0,1] = -1 * matrix_pt[1,0];
      adj[1,0] = -1 * matrix_pt[0,1];
      adj[1,1] = matrix_pt[0,0];
    }
  }
}