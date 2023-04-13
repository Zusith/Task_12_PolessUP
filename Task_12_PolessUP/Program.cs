string isbn = "3-598-21508-8";
Console.WriteLine(isbn);
Console.WriteLine(ISBN10Check(isbn));
isbn = "3-598-21508-9";
Console.WriteLine(isbn);
Console.WriteLine(ISBN10Check(isbn));
isbn = "3-598-21507-X";
Console.WriteLine(isbn);
Console.WriteLine(ISBN10Check(isbn));



bool ISBN10Check(string isbn)
{
    if (isbn.Contains('-'))
    {
        string[] masscheck = isbn.Split('-');
        isbn = isbn.Replace("-","");
        if (masscheck[0].Length == 1 && masscheck[1].Length == 3 && masscheck[2].Length == 5 && masscheck[3].Length == 1) { }
        else return false;
    }
    for (int index = 0; index < isbn.Length - 1; index++)
    {
        if (isbn[index] < '0' || isbn[index] > '9')
        return false;
    }
    if ((isbn[^1] > '0' && isbn[^1] < '9') || isbn[^1] == 'X') { }
    else return false;

    int CheckSum = 0;
    for (int index = 0, indexsum = 10; index < isbn.Length - 1; index++, indexsum--)
    { 
        CheckSum += int.Parse(Convert.ToString(isbn[index])) * indexsum;
    }
    if (isbn[^1] == 'X')
    CheckSum += 10;
    else CheckSum += int.Parse(Convert.ToString(isbn[^1]));

    if (CheckSum % 11 == 0)
    {
        return true;
    }
    return false;
}
