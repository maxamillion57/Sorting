using System;

class SortingAlgorithms
{
    // Bubble Sort
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // swap arr[j] and arr[j+1]
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    // Selection Sort
    static void SelectionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }
            // swap arr[i] and arr[minIndex]
            int temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;
        }
    }

    // Merge Sort
    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        Array.Copy(arr, left, L, 0, n1);
        Array.Copy(arr, mid + 1, R, 0, n2);

        int i = 0, j = 0;
        int k = left;
        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
            {
                arr[k] = L[i];
                i++;
            }
            else
            {
                arr[k] = R[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            arr[k] = L[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            arr[k] = R[j];
            j++;
            k++;
        }
    }

    // Utility function to print an array
    static void PrintArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }

    // Main method to interact with user
    static void Main()
    {
        Console.WriteLine("Enter integers separated by spaces:");
        string input = Console.ReadLine();
        string[] strArray = input.Split(' ');
        int[] arr = Array.ConvertAll(strArray, int.Parse);

        Console.WriteLine("Choose a sorting algorithm:");
        Console.WriteLine("1. Bubble Sort");
        Console.WriteLine("2. Selection Sort");
        Console.WriteLine("3. Merge Sort");
        Console.Write("Enter your choice (1, 2, or 3): ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                BubbleSort(arr);
                Console.WriteLine("\nSorted array using Bubble Sort:");
                PrintArray(arr);
                break;
            case 2:
                SelectionSort(arr);
                Console.WriteLine("\nSorted array using Selection Sort:");
                PrintArray(arr);
                break;
            case 3:
                MergeSort(arr, 0, arr.Length - 1);
                Console.WriteLine("\nSorted array using Merge Sort:");
                PrintArray(arr);
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }
}
