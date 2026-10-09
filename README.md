# Branching Test

Sample project for [*High Performance Unity Game Development (Using data-oriented design)*](https://www.manning.com/books/high-performance-unity-game-development) by Nitzan Wilnai (Manning).

This is a small benchmark, not a game. It runs the same loop four times. The loop has one `if`/`else` in it, and the work is the same each time. Only the pattern of true and false values changes. The question it answers: does the pattern of a branch change how fast the loop runs?

## What it shows

- A loop with one `if`/`else` inside, run over an array of ints.
- Four `bool` arrays decide which side of the `if` runs: always true, alternating, first half true, and random.
- Every element costs one add or one subtract in all four cases. Only the order of true and false is different.
- The time of each pattern as a percentage of the always-true case.

The pattern is what the CPU's branch predictor has to guess. A steady pattern is easy to guess and a random one is not. This test lets you see how much that costs on your device.

## How the test works

The test is in `Assets/Scripts/BranchTest.cs`.

- `Start()` fills `Array` with the numbers `0` to `ArraySize - 1` and fills the four `bool` arrays:
  - `BoolAlwaysTrueArray`: always true. This is the baseline.
  - `BoolMod2Array`: false, true, false, true... (`i % 2 != 0`)
  - `BoolHalfArray`: true for the first half, false for the second half.
  - `RandomArray`: random, about half true (`Random.value > 0.5f`).
- `RunTest()` is what the button calls. It calls `branchTest()`.
- `branchTest()` forces a garbage collection, then does `NumIterations` passes. In each pass it runs the loop once per `bool` array and adds up the time for each with `Time.realtimeSinceStartupAsDouble`.

This is the loop. Only the `bool` array changes between cases:

```csharp
for (int i = 0; i < ArraySize; i++)
{
    if (BoolMod2Array[i])
        value += Array[i];
    else
        value -= Array[i];
}
```

`Assets/Scripts/Main2.cs` holds a longer list of experiments: `if (i % N == 0)` conditions, a multiply against an `if` on a `bool`, a loop over half the array, and setting a `GameObject` position with and without a null check. It is not attached to any object in the scene, so it does not run.

## Running it

1. Open the project in Unity **6000.3.22f1** (Unity 6.3 LTS) or newer.
2. Open `Assets/Scenes/SampleScene.unity` and press **Play**.
3. Click **Run Test**. The app freezes while the test runs. Then three lines of results appear on screen. The Console also logs `Result:` followed by the running total from the loops.

You can change `NumIterations` and `ArraySize` on the `BranchTest` object in the scene. They are set to 10000 and 4096.

## Reading the results

```
Array Bool Mod2: <seconds> seconds <percent>%
Array Bool Half: <seconds> seconds <percent>%
Array Bool Random: <seconds> seconds <percent>%
```

- `<seconds>` is the total time for all passes of that pattern.
- `<percent>` is that time as a percentage of the always-true case. `100%` means the same speed. A higher number means slower.
- The always-true time itself is not printed. It is only used as the baseline.

The numbers depend on your CPU and on whether you run in the Editor or in a build. Run it on the device you care about.

## More samples

All sample projects for the book: https://github.com/Data-Oriented-Design-for-Games
