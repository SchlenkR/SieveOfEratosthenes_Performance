
Sieve of Eratosthenes - Performance in F#
===

This is a simple performance comparison of several imperative implementations of the
[Sieve of Eratosthenes](https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes).

It uses [Benchmark Dotnet](https://github.com/dotnet/BenchmarkDotNet) for performance analysis.

Results
---

*n = 10_000_000*

| Method |           Job |       Runtime |         N |       Mean |    Error |   StdDev |     Median |
|------- |-------------- |-------------- |---------- |-----------:|---------:|---------:|-----------:|
|    For |    .NET 4.7.2 |    .NET 4.7.2 |  10000000 |   222.9 ms |  2.53 ms |  2.24 ms |   223.3 ms |
|  While |    .NET 4.7.2 |    .NET 4.7.2 |  10000000 |   140.5 ms |  2.79 ms |  4.51 ms |   139.7 ms |
|   Iter |    .NET 4.7.2 |    .NET 4.7.2 |  10000000 |   235.5 ms |  4.35 ms |  6.09 ms |   234.2 ms |
|  PIter |    .NET 4.7.2 |    .NET 4.7.2 |  10000000 |   162.2 ms |  3.52 ms | 10.33 ms |   162.9 ms |
|    Rec |    .NET 4.7.2 |    .NET 4.7.2 |  10000000 |   139.4 ms |  2.72 ms |  3.81 ms |   138.2 ms |
|    For | .NET Core 3.0 | .NET Core 3.0 |  10000000 |   202.6 ms |  3.77 ms |  3.52 ms |   203.2 ms |
|  While | .NET Core 3.0 | .NET Core 3.0 |  10000000 |   136.6 ms |  1.90 ms |  1.69 ms |   137.0 ms |
|   Iter | .NET Core 3.0 | .NET Core 3.0 |  10000000 |   219.6 ms |  3.84 ms |  3.00 ms |   220.4 ms |
|  PIter | .NET Core 3.0 | .NET Core 3.0 |  10000000 |   166.5 ms |  3.30 ms |  5.23 ms |   166.8 ms |
|    Rec | .NET Core 3.0 | .NET Core 3.0 |  10000000 |   146.7 ms |  2.93 ms |  7.93 ms |   144.1 ms |


*n = 50_000_000*

| Method |           Job |       Runtime |         N |       Mean |    Error |   StdDev |     Median |
|------- |-------------- |-------------- |---------- |-----------:|---------:|---------:|-----------:|
|    For |    .NET 4.7.2 |    .NET 4.7.2 |  50000000 | 1,256.0 ms | 24.37 ms | 29.01 ms | 1,254.0 ms |
|  While |    .NET 4.7.2 |    .NET 4.7.2 |  50000000 |   847.6 ms | 16.35 ms | 16.06 ms |   850.2 ms |
|   Iter |    .NET 4.7.2 |    .NET 4.7.2 |  50000000 | 1,245.8 ms |  7.06 ms |  6.60 ms | 1,245.5 ms |
|  PIter |    .NET 4.7.2 |    .NET 4.7.2 |  50000000 |   916.6 ms | 18.10 ms | 22.89 ms |   918.0 ms |
|    Rec |    .NET 4.7.2 |    .NET 4.7.2 |  50000000 |   811.1 ms |  6.20 ms |  5.49 ms |   809.7 ms |
|    For | .NET Core 3.0 | .NET Core 3.0 |  50000000 | 1,120.0 ms |  6.24 ms |  5.53 ms | 1,118.9 ms |
|  While | .NET Core 3.0 | .NET Core 3.0 |  50000000 |   810.8 ms |  5.45 ms |  4.83 ms |   810.9 ms |
|   Iter | .NET Core 3.0 | .NET Core 3.0 |  50000000 | 1,241.0 ms | 12.84 ms | 12.01 ms | 1,238.6 ms |
|  PIter | .NET Core 3.0 | .NET Core 3.0 |  50000000 |   935.4 ms | 18.65 ms | 22.20 ms |   939.0 ms |
|    Rec | .NET Core 3.0 | .NET Core 3.0 |  50000000 |   825.6 ms |  8.84 ms |  8.27 ms |   822.5 ms |


*n = 100_000_000*

| Method |           Job |       Runtime |         N |       Mean |    Error |   StdDev |     Median |
|------- |-------------- |-------------- |---------- |-----------:|---------:|---------:|-----------:|
|    For |    .NET 4.7.2 |    .NET 4.7.2 | 100000000 | 2,527.1 ms | 38.26 ms | 33.92 ms | 2,522.6 ms |
|  While |    .NET 4.7.2 |    .NET 4.7.2 | 100000000 | 1,669.8 ms |  8.86 ms |  7.85 ms | 1,671.6 ms |
|   Iter |    .NET 4.7.2 |    .NET 4.7.2 | 100000000 | 2,568.5 ms | 26.21 ms | 24.52 ms | 2,565.6 ms |
|  PIter |    .NET 4.7.2 |    .NET 4.7.2 | 100000000 | 1,916.0 ms | 36.99 ms | 37.98 ms | 1,933.6 ms |
|    Rec |    .NET 4.7.2 |    .NET 4.7.2 | 100000000 | 1,726.5 ms | 33.60 ms | 41.27 ms | 1,707.2 ms |
|    For | .NET Core 3.0 | .NET Core 3.0 | 100000000 | 2,321.0 ms | 24.18 ms | 21.44 ms | 2,318.7 ms |
|  While | .NET Core 3.0 | .NET Core 3.0 | 100000000 | 1,725.1 ms | 30.83 ms | 28.84 ms | 1,715.2 ms |
|   Iter | .NET Core 3.0 | .NET Core 3.0 | 100000000 | 2,496.8 ms |  4.15 ms |  3.68 ms | 2,496.1 ms |
|  PIter | .NET Core 3.0 | .NET Core 3.0 | 100000000 | 2,014.6 ms | 39.91 ms | 72.98 ms | 2,028.1 ms |

