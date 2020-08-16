namespace Benchmark

open BenchmarkDotNet.Attributes

[<SimpleJob(RuntimeMoniker.Net472)>]
[<SimpleJob(RuntimeMoniker.NetCoreApp30)>]
type SieveOfEratosthenes() =
    [<Params(10_000_000, 50_000_000, 100_000_000)>]
    member val N = 10_000 with get, set

    [<Benchmark>]
    member this.For() = SieveOfEratosthenes.siebFor this.N

    [<Benchmark>]
    member this.While() = SieveOfEratosthenes.siebWhile this.N

    [<Benchmark>]
    member this.Iter() = SieveOfEratosthenes.siebIter this.N

    [<Benchmark>]
    member this.PIter() = SieveOfEratosthenes.siebPIter this.N

    [<Benchmark>]
    member this.Rec() = SieveOfEratosthenes.siebRec this.N

module Program =
    open BenchmarkDotNet.Running

    [<EntryPoint>]
    let main _ =
        BenchmarkRunner.Run<SieveOfEratosthenes>() |> ignore
        0