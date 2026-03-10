using NUnit.Framework;


//[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(2)]
[assembly: Parallelizable(ParallelScope.None)]
