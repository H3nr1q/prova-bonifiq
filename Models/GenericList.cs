namespace ProvaPub.Models
{
    public class GenericList<T>
    {
        public List<T> ListItems { get; set; }
        public int TotalCount { get; set; }
        public bool HasNext { get; set; }
    }
}
