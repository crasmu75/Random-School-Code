using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q4_2
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] A = {1,2,3,4};
			int[] B = {5,6,7,8};
			Console.WriteLine(select1(A, B, 2));
		}

		// A and B are each sorted into ascending order, and 0 <= k < |A|+|B| 
// Returns the element that would be stored at index k if A and B were
// combined into a single array that was sorted into ascending order.
public static int select1 (int[] A, int[] B, int k)
{
    return select(A, 0, A.Length-1, B, 0, B.Length-1, k);
}

public static int select(int[] A, int loA, int hiA, int[] B, int loB, int hiB, int k)
{
    // A[loA..hiA] is empty
    if(hiA < loA)
        return B[k-loA];
    // B[loB..hiB] is empty
    if(hiB < loB)
        return A[k-loB];
    // Get the midpoints of A[loA..hiA] and B[loB..hiB]
    int i = (loA+hiA)/2;
    int j = (loB+hiB)/2;
    // Figure out which one of four cases apply
    if (A[i] <= B[j])
	{
        if (k > i+j)
            return select(A, i+1, hiA, B, loB, hiB, k);
        else
            return select(A, loA, hiA, B, loB, j-1, k);
	}
    else
	{
		if (k > i + j)
			return select(A, loA, hiA, B, j+1, hiB, k);
		else
			return select(A, loA, i-1, B, loB, hiB, k);
	}
	}
}
}
