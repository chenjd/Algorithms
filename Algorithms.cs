// Author : 陈嘉栋
// Date   : 2015-05-19
// Blog   : http://www.cnblogs.com/murongxiaopifu/
// 常见排序算法实现
using System;
using System.Collections.Generic;
class Program
{
  static int[]arr={23,44,66,76,98,11,3,9,7};

  static void Main(string[]args)
  {
    // InsertionSort();
    // BubbleSort();
    QuickSort();
  }
  ///<summary>
  ///插入排序法
  ///</summary>
  private static void InsertionSort()
  {
    Console.WriteLine("插入排序法");
    int[]arr={23,44,66,76,98,11,3,9,7};
    
    Console.WriteLine("排序前的数组：");
    foreach(int item in arr)
    {
      Console.Write(item+",");
    }
    Console.WriteLine();
    
    var length=arr.Length;
    
    for(int i=1;i<length;i++)
    {
      for(int j=i; j>0;j--)
      {
        if(arr[j]>arr[j-1])
        {
          arr[j] = arr[j] ^ arr[j-1];
          arr[j-1] = arr[j] ^ arr[j-1];
          arr[j] = arr[j] ^ arr[j-1];
        }
      }
        //每次排序后数组
        PrintResult(arr);
    }
  }
  ///<summary>
  ///冒泡排序法
  ///</summary>
  private static void BubbleSort()
  {
    Console.WriteLine("冒泡排序法");
    int[]arr={23,44,66,76,98,11,3,9,7};
    
    Console.WriteLine("排序前的数组：");
    foreach(int item in arr)
    {
      Console.Write(item+",");
    }
    Console.WriteLine();
    var length = arr.Length;
    for(int i = 0; i < length; i++)
    {
      for(int j = i + 1; j < length; j++)
      {
        if(arr[i] < arr[j])
        {
          arr[i] = arr[i] ^ arr[j];
          arr[j] = arr[i] ^ arr[j];
          arr[i] = arr[i] ^ arr[j];
        }
      }
      PrintResult(arr);
    }
  }
  ///<summary>
  ///冒泡排序法
  ///</summary>
  //快速排序法
  //选定一个标准值temp
  //通过一趟排序将要排序的数据分割成独立的两部分，
  //其中一部分的所有数据都比temp小
  //另外一部分的所有数据都要比temp大，
  //然后再按此方法对这两部分数据分别进行快速排序，整个排序过程可以递归进行，
  //以此达到整个数据变成有序序列。
  private static void QuickSort()
  {
    Console.WriteLine("快速排序法");
    
    Console.WriteLine("排序前的数组：");
    foreach(int item in arr)
    {
      Console.Write(item+",");
    }
    Console.WriteLine();
    var length = arr.Length;
    QuickSortExcute(0, length - 1);
  }
  private static void QuickSortExcute(int left, int right)
  {
    if(left >= right)
      return;
    int temp = arr[left];
    int l = left;
    int r = right;
    while(left < right)
    {
      while(arr[right] >= temp && left < right) right--;
      arr[left] = arr[right];
      while(arr[left] <= temp && left < right) left++;
      arr[right] = arr[left];
    }
    arr[right] = temp;
    PrintResult(arr);
    QuickSortExcute(l, left - 1);
    QuickSortExcute(left + 1, r);
    return;
  }


  ///<summary>
  ///打印结果
  ///</summary>
  ///<paramname="arr"></param>
  private static void PrintResult(IEnumerable<int>arr)
  {
    foreach(int item in arr)
    {
      Console.Write(item+",");
    }
    Console.WriteLine();
  }
}

