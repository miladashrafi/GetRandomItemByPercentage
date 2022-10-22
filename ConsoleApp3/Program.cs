// See https://aka.ms/new-console-template for more information

int onePercentage = 30, twoPercentage = 70;

var list = Enumerable.Repeat("One", onePercentage).ToList();
list.AddRange(Enumerable.Repeat("Two", twoPercentage));

var all = new List<string>();

while (true)
{
    var item = list.OrderBy(x => Guid.NewGuid()).First();
    all.Add(item);
    var items = all.GroupBy(x => x).Select(x => new { x.Key, Count = x.Count() });

    var one = items.SingleOrDefault(x => x.Key == "One")?.Count ?? 0;
    var two = items.SingleOrDefault(x => x.Key == "Two")?.Count ?? 0;

    Console.WriteLine($"Set-points => One: {onePercentage}% / Two: {twoPercentage}% | " +
        $"Current: {item} | " +
        $"Percentage => One: {one * 100 / all.Count}% / Two: {two * 100 / all.Count}% | " +
        $"Total: {all.Count}");
    Thread.Sleep(Random.Shared.Next(50, 500));
    Console.Clear();
}

