
int onePercentage = 30, twoPercentage = 70;

var all = new List<string>();

while (true)
{
    var x = Random.Shared.Next(1, 100);
    var item = onePercentage > x ? "One" : "Two";

    all.Add(item);
    var items = all.GroupBy(x => x).Select(x => new { x.Key, Count = x.Count() });

    var one = items.SingleOrDefault(x => x.Key == "One")?.Count ?? 0;
    var two = items.SingleOrDefault(x => x.Key == "Two")?.Count ?? 0;

    Console.WriteLine($"Set-points => One: {onePercentage}% / Two: {twoPercentage}% | " +
        $"Current: {item} | " +
        $"Actual Percentage => One: {one * 100 / all.Count}% / Two: {two * 100 / all.Count}% | " +
        $"Total: {all.Count}");
    Thread.Sleep(Random.Shared.Next(50, 500));
    Console.Clear();
}
