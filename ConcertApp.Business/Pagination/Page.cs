namespace ConcertApp.Business.Pagination
{
    public class Page<T>
    {
        public int NoItems { get; set; }
        public List<T> Items { get; set; }
    }
}
