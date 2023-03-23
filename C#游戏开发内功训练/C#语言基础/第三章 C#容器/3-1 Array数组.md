# Array 数组

## 1. C# 数组

### 1.1 数组概念

数组是一个存储相同类型元素的固定大小的顺序集合。

数组可以存储任意类型的数据，但一个数组中，所有元素类型必须相同，除非是 Object 类型数组。

数组是用来存储数据的容器，通常认为数组是一个同一类型变量的集合。

> 注意：
> C# 中，数组底层是基于 Array 类来实现的， 数组类型是从抽象基类型 Array 派生的引用类型。
> 在C#中，数组实际上是对象，而不只是像 C 和 C++ 中那样的可寻址连续内存区域。
> Array 是所有数组类型的抽象基类型。可以使用 Array 具有的属性以及其他类成员。 
> 但是，只有系统和编译器能够从 Array 类显式派生。用户应当使用由语言提供的数组语法来进行数组的建构。

### 1.2 数组使用

### 创建

数组创建时必须指定大小

``` C#
// 格式
数据类型[]  数组对象名 = new [数组长度]; 

// 示例
// 创建长度为5的整型数组
int[] array = new int[5];
// 创建长度为6 的字符串数组
string[] stringArray = new string[6];
```

### 初始化、赋值

``` C#
// 创建时直接赋值
int[] array1 = new int[] { 1, 3, 5, 7, 9 };
string[] weekDays = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

// 简化形式
int[] array2 = { 1, 3, 5, 7, 9 };
string[] weekDays2 = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

// 声明和初始化分成两步
int[] array3;
array3 = new int[] { 1, 3, 5, 7, 9 };
```

### 访问数组项

数组通过索引来访问数组项，索引 i 访问的是第 i+1 项，因为长度为 n 的数组索引是 0 到 n-1

``` C#
// 赋值
数组对象名[i] = 5 
// 取值
int a= 数组对象名[i]
```
### 1.3 数组特点

* 数组可以是一维、多维或交错的。
* 数组可以作为实参传递给方法形参。 由于数组是引用类型，因此方法可以更改元素的值。
* 创建数组实例时，将建立纬度数量和每个纬度的长度。 这些值在实例的生存期内无法更改。
* 数值数组元素的默认值设置为零，而引用元素设置为 null。
* 交错数组是数组的数组，因此其元素为引用类型且被初始化为 null。
* 数组从零开始编制索引：包含 n 元素的数组从 0 索引到 n-1。
* 数组元素可以是任何类型，其中包括数组类型。
* 数组类型是从抽象的基类型 Array 派生的引用类型。 所有数组都会实现 IList 和 IEnumerable。 可以使用 foreach 语句循环访问数组。 单维数组还实现了 IList<T> 和 IEnumerable<T>。

### 1.4 多维数组

数组可具有多个维度

``` C#
//创建 4*2 二维数组
int[,] array = new int[4, 2];

// 创建 4*2*3 的三维数组
int[,,] array1 = new int[4,2,3];

// 初始化多维数组
int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
// The same array with dimensions specified.
int[,] array2Da = new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
// A similar array with string elements.
string[,] array2Db = new string[3, 2] { { "one", "two" }, { "three", "four" },
                                        { "five", "six" } };

// Three-dimensional array.
int[,,] array3D = new int[,,] { { { 1, 2, 3 }, { 4, 5, 6 } },
                                 { { 7, 8, 9 }, { 10, 11, 12 } } };
// The same array with dimensions specified.
int[,,] array3Da = new int[2, 2, 3] { { { 1, 2, 3 }, { 4, 5, 6 } },
                                       { { 7, 8, 9 }, { 10, 11, 12 } } };

```

### 1.5 交错数组

交错数组是一个数组，其元素是数组，大小可能不同。 

交错数组和多维数组的区别：
1. 交错数组是数组，在面向对象的逻辑结构上不同
2. 交错数组中的每个子数组维度可以不同


``` C#
// 创建交错数组

//声明一个具有三个元素的一维数组，其中每个元素都是一维整数数组：
int[][] jaggedArray = new int[3][];
//初始化
jaggedArray[0] = new int[5];
jaggedArray[1] = new int[4];
jaggedArray[2] = new int[2];
//或者：
jaggedArray[0] = new int[] { 1, 3, 5, 7, 9 };
jaggedArray[1] = new int[] { 0, 2, 4, 6 };
jaggedArray[2] = new int[] { 11, 22 };
//或者：
int[][] jaggedArray2 = new int[][]
{
    new int[] { 1, 3, 5, 7, 9 },
    new int[] { 0, 2, 4, 6 },
    new int[] { 11, 22 }
};

//访问个别数组元素：
jaggedArray3[0][1] = 77;
jaggedArray3[2][1] = 88;
```

可以混合使用交错数组和多维数组。

``` C#
// 创建一个包含3个二维数组的交错数组
int[][,] jaggedArray4 = new int[3][,]
{
    new int[,] { {1,3}, {5,7} },
    new int[,] { {0,2}, {4,6}, {8,10} },
    new int[,] { {11,22}, {99,88}, {0,9} }
};
// 访问数组项
jaggedArray4[0][1, 0] = 5;
```

### 1.6 遍历数组

foreach 语句提供一种简单、明了的方法来循环访问数组的元素。

对于单维数组，foreach 语句以递增索引顺序处理元素（从索引 0 开始并以索引 Length - 1 结束）

``` C#
int[] numbers = { 4, 5, 6, 1, 2, 3, -2, -1, 0 };
foreach (int i in numbers)
{
    System.Console.Write("{0} ", i);
}
// Output: 4 5 6 1 2 3 -2 -1 0
```

对于多维数组，遍历元素的方式为：首先增加最右边维度的索引，然后是它左边的一个维度，以此类推，向左遍历元素：

``` C#
int[,] numbers2D = new int[3, 2] { { 9, 99 }, { 3, 33 }, { 5, 55 } };
// Or use the short form:
// int[,] numbers2D = { { 9, 99 }, { 3, 33 }, { 5, 55 } };

foreach (int i in numbers2D)
{
    System.Console.Write("{0} ", i);
}
// Output: 9 99 3 33 5 55
```

## 2. C# Array 类型

Array 类是 C# 中所有数组的基类，它是在 System 命名空间中定义。

Array 类提供了各种用于数组的属性和方法。

### 2.1 Array 常用属性

1.	IsFixedSize  
获取一个值，该值指示数组是否带有固定大小。
2.	IsReadOnly  
获取一个值，该值指示数组是否只读。
3.	Length  
获取一个 32 位整数，该值表示所有维度的数组中的元素总数。
4.	LongLength  
获取一个 64 位整数，该值表示所有维度的数组中的元素总数。
5.	Rank  
获取数组的秩（维度）。

### 2.2 Array 常用方法

1.	Clear  
根据元素的类型，设置数组中某个范围的元素为零、为 false 或者为 null。
2.	Copy(Array, Array, Int32)  
从数组的第一个元素开始复制某个范围的元素到另一个数组的第一个元素位置。长度由一个 32 位整数指定。
3.	CopyTo(Array, Int32)  
从当前的一维数组中复制所有的元素到一个指定的一维数组的指定索引位置。索引由一个 32 位整数指定。
4.	GetLength  
获取一个 32 位整数，该值表示指定维度的数组中的元素总数。
5.	GetLongLength  
获取一个 64 位整数，该值表示指定维度的数组中的元素总数。
6.	GetLowerBound  
获取数组中指定维度的下界。
7.	GetType  
获取当前实例的类型。从对象（Object）继承。
8.	GetUpperBound  
获取数组中指定维度的上界。
9.	GetValue(Int32)  
获取一维数组中指定位置的值。索引由一个 32 位整数指定。
10.	IndexOf(Array, Object)  
搜索指定的对象，返回整个一维数组中第一次出现的索引。
11.	Reverse(Array)  
逆转整个一维数组中元素的顺序。
12.	SetValue(Object, Int32)  
给一维数组中指定位置的元素设置值。索引由一个 32 位整数指定。
13.	Sort(Array)  
使用数组的每个元素的 IComparable 实现来排序整个一维数组中的元素。
14.	ToString  
返回一个表示当前对象的字符串。从对象（Object）继承。

## 3. 优缺点

### 3.1 优点

* 数组在C#中是最早出现的。
* 它在内存中是连续的存储的，所以索引速度很快，而且赋值与修改元素也很简单。
* 可以利用偏移地址访问元素，时间复杂度为O(1)。
* 可以用折半查找法查找元素，效率高。

### 3.2 缺点

* 固定长度：在声明数组的时候，必须同时指明数组的长度，数组的长度过长，会造成内存浪费，数组的长度过短，会造成数据溢出的错误。
* 插入、删除慢：空间的连续，导致了存储效率低，插入和删除元素效率比较低，而且麻烦。

<br>
<hr>
<br>

> 参考资料
> * [C# 微软官方文档](https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/arrays/)