using System.Collections.Generic;
using ExchangeGateway.Models.EntityModels;

namespace ExchangeGateway.CommonAlgorithms.Sorting {
    public static class InsertionSort {
        // Function to sort array
        // using insertion sort
        public static List<Product> sort (List<Product> arr) {
            int n = arr.Count;
            for (int i = 1; i < n; ++i) {
                Product key = arr[i];
                int j = i - 1;

                // Move elements of arr[0..i-1],
                // that are greater than key,
                // to one position ahead of
                // their current position
                while (j >= 0 && arr[j].UnitPrice > key.UnitPrice) {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
            return arr;
        }
        public static int[] sort (int[] arr) {
            int n = arr.Length;
            for (int i = 1; i < n; ++i) {
                int key = arr[i];
                int j = i - 1;

                // Move elements of arr[0..i-1],
                // that are greater than key,
                // to one position ahead of
                // their current position
                while (j >= 0 && arr[j] > key) {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
            return arr;
        }
    }
}