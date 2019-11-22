<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Numerics</Namespace>
</Query>

// Lessons learned from this, very big numbers cannot be fed as they are, but need to be parsed from a string
// BigInteger needs BigInteger.Pow to be called when using numbers to the power of
// This method can only be called on 2 numbers of the same digit length

void Main()
{
	BigInteger x = BigInteger.Parse("3141592653589793238462643383279502884197169399375105820974944592");
	BigInteger y = BigInteger.Parse("2718281828459045235360287471352662497757247093699959574966967627");
	
	Console.WriteLine(x * y);
	Console.WriteLine(Multi(x, y));
}

public BigInteger Multi(BigInteger x, BigInteger y) 
{
	if (x < 10 && y < 10) return x * y;
	
	int n = x.ToString().Length;
	int halfn = (int)Math.Ceiling((double)n / 2);
	BigInteger splitter = (BigInteger)BigInteger.Pow(10, halfn);
	
	BigInteger a, b, c, d;
	a = x / splitter;
	b = x - (a * splitter);
	c = y / splitter;
	d = y - (c * splitter);
	
	BigInteger s1 = Multi(a, c) * (BigInteger)BigInteger.Pow(10, halfn * 2);
	BigInteger s2 = Multi(b, d);
	BigInteger s3 = (Multi(a, d) + Multi(b, c)) * (BigInteger)BigInteger.Pow(10, halfn);
	//long result = s1 + s2 + s3;
	return s1 + s2 + s3;
}
// Define other methods and classes here