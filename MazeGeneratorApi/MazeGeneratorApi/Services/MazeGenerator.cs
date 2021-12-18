/*=== Autor: Darwin E. Quiroz ===*/
public class MazeGenerator
{
    public int nMax = 0;
    public int mMax = 0;
    private readonly Random _random = new Random();

    public int[,] M = new int[,] { };
    const int BLOQUE = 1;
    const int LIBRE = 0;

    public void agregarParOrdenado(int[,] A, ref int k, int a, int b)
    {
        bool Esta = false;
        for (int i = 0; i < k; i++)
        {
            if (a == A[i, 0] && b == A[i, 1])
            {
                Esta = true;
                break;
            }
        }
        if (Esta == false)
        {
            A[k, 0] = a;
            A[k, 1] = b;
            k++;
        }
    }

    public void obtenerParOrdenadoRandom(int[,] a, ref int k, ref int x, ref int y)
    {
        int index = _random.Next(0, k - 1); //range 0 to k-1
        x = a[index, 0];
        y = a[index, 1];
        for (int i = index; i < k; i++)
        {
            a[i, 0] = a[i + 1, 0];
            a[i, 1] = a[i + 1, 1];
        }
        k--;
    }


    void crearLaberinto(int[,] M, int m, int n)
    {
        int[,] ID_VECINOS_BLOQUEADOS = new int[m + n, 2];
        int[,] ID_VECINOS_DESBLOQUEADOS = new int[4, 2];
        int kb = 0, kd = 0, maxBlock = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                M[i, j] = BLOQUE;
            }
        }
        int Oi, Oj, Ii = 0, Ij = 0;
        Oi = 1; Oj = 1;
        M[Oi, Oj] = LIBRE;
        if (Oj - 2 > 0 && M[Oi, Oj - 2] == BLOQUE)
        {
            agregarParOrdenado(ID_VECINOS_BLOQUEADOS, ref kb, Oi, Oj - 2);
        }
        if (Oj + 2 < n && M[Oi, Oj + 2] == BLOQUE)
        {
            agregarParOrdenado(ID_VECINOS_BLOQUEADOS, ref kb, Oi, Oj + 2);
        }
        if (Oi - 2 > 0 && M[Oi - 2, Oj] == BLOQUE)
        {
            agregarParOrdenado(ID_VECINOS_BLOQUEADOS, ref kb, Oi - 2, Oj);
        }
        if (Oi + 2 < m && M[Oi + 2, Oj] == BLOQUE)
        {
            agregarParOrdenado(ID_VECINOS_BLOQUEADOS, ref kb, Oi + 2, Oj);
        }
        int count = 0;
        while (kb > 0)
        {
            if (maxBlock < kb)
            {
                maxBlock = kb;
            }
            obtenerParOrdenadoRandom(ID_VECINOS_BLOQUEADOS, ref kb, ref Oi, ref Oj);//a) y g)
                                                                                    //agregando vecinos desbloqueados
            kd = 0;
            if (Oj - 2 > 0 && M[Oi, Oj - 2] == LIBRE)
            {
                agregarParOrdenado(ID_VECINOS_DESBLOQUEADOS, ref kd, Oi, Oj - 2);
            }
            if (Oj + 2 < n && M[Oi, Oj + 2] == LIBRE)
            {
                agregarParOrdenado(ID_VECINOS_DESBLOQUEADOS, ref kd, Oi, Oj + 2);
            }
            if (Oi - 2 > 0 && M[Oi - 2, Oj] == LIBRE)
            {
                agregarParOrdenado(ID_VECINOS_DESBLOQUEADOS, ref kd, Oi - 2, Oj);
            }
            if (Oi + 2 < m && M[Oi + 2, Oj] == LIBRE)
            {
                agregarParOrdenado(ID_VECINOS_DESBLOQUEADOS, ref kd, Oi + 2, Oj);
            }
            obtenerParOrdenadoRandom(ID_VECINOS_DESBLOQUEADOS, ref kd, ref Ii, ref Ij);//c)
            if (Ii == Oi)
            {//d)
                if (Ij < Oj)
                {
                    M[Ii, Ij + 1] = LIBRE;
                }
                else
                {
                    M[Ii, Oj + 1] = LIBRE;
                }
            }
            else
            {
                if (Ii < Oi)
                {
                    M[Ii + 1, Ij] = LIBRE;
                }
                else
                {
                    M[Oi + 1, Ij] = LIBRE;
                }
            }
            M[Oi, Oj] = LIBRE; //f)
                               //agregando vecinos bloqueados
            if (Oj - 2 > 0 && M[Oi, Oj - 2] == BLOQUE)
            {
                agregarParOrdenado(ID_VECINOS_BLOQUEADOS, ref kb, Oi, Oj - 2);
            }
            if (Oj + 2 < n && M[Oi, Oj + 2] == BLOQUE)
            {
                agregarParOrdenado(ID_VECINOS_BLOQUEADOS, ref kb, Oi, Oj + 2);
            }
            if (Oi - 2 > 0 && M[Oi - 2, Oj] == BLOQUE)
            {
                agregarParOrdenado(ID_VECINOS_BLOQUEADOS, ref kb, Oi - 2, Oj);
            }
            if (Oi + 2 < m && M[Oi + 2, Oj] == BLOQUE)
            {
                agregarParOrdenado(ID_VECINOS_BLOQUEADOS, ref kb, Oi + 2, Oj);
            }
            count++;
        }
    }

    public void crearLaberinto(int n,int m)
    {
        nMax = n;
        mMax = m;
        M = new int[nMax, mMax];
        crearLaberinto(M, mMax, nMax);
    }
}