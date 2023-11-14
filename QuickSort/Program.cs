int[] Lista = {60, 2003, 35, 100, 9900};

static int soma(int[] arr)
{
    if(arr.Length == 0) return 0;
    return arr[0] + soma(arr.Skip(1).ToArray()); 
}

Console.WriteLine(soma(Lista));

static int numItem(int[] lista)
{
    if(lista.Length == 0) return 0;
    var fodase =   1 + numItem(lista.Skip(1).ToArray());
    return fodase;
}

Console.WriteLine(numItem(Lista));

static int max(int[] arr)
{
    if(arr.Length == 1) return arr.First();
    var subMax = arr[0];
    if(subMax < max(arr.Skip(1).ToArray())) subMax = max(arr.Skip(1).ToArray());
    return subMax;
}

Console.WriteLine(max(Lista));

static int loopMav(int[] arr)
{
    int submax = arr[0];
    for(int i = 0; i <= arr.Length; i++)
    {
        if(submax < arr[i]) submax = arr[i];
        if(i == arr.Length -1) return submax;
    }
    return submax;
}

Console.WriteLine(loopMav(Lista));