namespace Benchmark

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Jobs

[<SimpleJob(RuntimeMoniker.Net472, baseline = true)>]
[<SimpleJob(RuntimeMoniker.NetCoreApp30)>]
type SieveOfEratosthenes() =

    [<Params(10_000_000, 50_000_000, 100_000_000)>]
    let mutable n = Unchecked.defaultof<int>

    [<Benchmark>]
    member this.For() = SieveOfEratosthenes.siebFor n

    [<Benchmark>]
    member this.While() = SieveOfEratosthenes.siebWhile n

    [<Benchmark>]
    member this.Iter() = SieveOfEratosthenes.siebIter n

    [<Benchmark>]
    member this.PIter() = SieveOfEratosthenes.siebPIter n

    [<Benchmark>]
    member this.Rec() = SieveOfEratosthenes.siebRec n

