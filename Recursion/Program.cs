static void Count(int i)
{
    Console.Write(i);
    
    if(i <= 0) return;

    Count(i - 1);
}

Count(5);