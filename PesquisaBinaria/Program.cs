var myList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
Console.WriteLine(PesquisaBinaria(myList, 3));
Console.WriteLine(PesquisaBinaria(myList, -1));

static int? PesquisaBinaria(IList<int> list, int item)
{
    var baixo = 0;
    var alto = list.Count - 1;

    while (baixo <= alto)
    {
        var meio = (baixo + alto) / 2;
        var chute = list[meio];
        if (chute == item) return meio;
        if (chute > item)
        {
            alto = meio - 1;
        }
        else
        {
            baixo = meio + 1;
        }
    }
    return null;
}