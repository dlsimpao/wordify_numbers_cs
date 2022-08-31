public class Program
{
	public static void Main()
	{
		string[] tests = {"0","1","10","11","19","20","21","99","100","101","1000","1234","12345","123456","1234567","12345678","123456789","1234567890","1234567890123456789012345"};
		foreach(string input in tests){
			wordify_number(input);
		}
		
	}
	public static void wordify_number(string num)
	{
		string[] singles = {"", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
		string[] teens = {"ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};
		string[] tenths = {"", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"};
		string[] places = {"","thousand","million","billion","trillion","quadrillion", "quintillion", "sextillion", "septillion"};
		
		string ans = "";		

		char[] chars = num.ToCharArray();
		Dictionary<int, int> map = new Dictionary<int, int>();

		for(int i = chars.Count(); i > 0; i--){
			int digit = (int) Char.GetNumericValue( chars[chars.Count() - i] );
			map.Add(i, digit);
		}

		if (num == "0"){ans = "zero";}
		
		foreach(var item in map){
			if(item.Key % 3 != 1 && item.Value == 0){
				continue;
			}else if(item.Key % 3 == 0){
				ans += singles[item.Value] + " hundred ";
			}else if(item.Key % 3 == 1 && item.Key == 1){
				ans += singles[item.Value] + " ";
			}else if(item.Key % 3 == 1){
				if(item.Value == 0){ans += places[(item.Key-1)/3] + " ";}
				else{ans += singles[item.Value] + " " + places[(item.Key-1)/3] + " ";}
			}else{
				if(item.Value == 1){//teens
					ans += teens[map[item.Key-1]] + " ";
					map[item.Key-1] = 0;
				}else{//above 20 below 100
					ans += tenths[item.Value] + " " ;
				}
			}
		}
		Console.WriteLine("\nInput:" + num.ToString() + "\nWord:" + ans);
	}
}