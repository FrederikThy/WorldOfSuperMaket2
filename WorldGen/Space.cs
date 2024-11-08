/* Space class for modeling spaces (rooms, caves, ...)
 */

using WorldOfSuperMaket;
using WorldOfSuperMaket.Inventory;

class Space : Node
{
    private CheckOut checkOut = new CheckOut();
    public Space(String name) : base(name)
    {
    }
    
    public string Name { get; set; }
    private List<Items> items; 
    
    public void AddItem(Items item)
    {
        items.Add(item); // Add item to a space (eg. Meats)
    }
    
    public List<Items> GetItems()
    {
        return items; // get the items from a space (eg. Meats)
    }

    public void Welcome()
    {
        Console.WriteLine("Du er nu ved: " + name);
        HashSet<string> exits = edges.Keys.ToHashSet();
        Console.WriteLine("Udgangene er nu ved: ");
        foreach (String exit in exits)
        {
            Console.WriteLine(" - " + exit);
        }
    }
    public string GetName()
    {
        return name;
    }
    public void Goodbye()
    {
    }
    public void Checkout(Items[] inv,UserInfo userInfo,double Klimaneutral)
    {
        var info = userInfo;
        double CaloriesInCart = inv.Sum(i => i.Calorie);

        bool EnoughCalories = CaloriesInCart >= userInfo.DaliyCalo;

        if (name.Equals("Checkout") && EnoughCalories)
        {
            CheckOut checkOut = new CheckOut(); 
            checkOut.DoCheckOut(inv,userInfo);
        }
        else
        {
            Console.WriteLine("Du mangler at tilføje flere kalorier til din kurv, før du kan gå til kassen.");
        }
    }

    public Space FollowEdge(string direction)
    {
        return (Space)(base.FollowEdge(direction));
    }
}
