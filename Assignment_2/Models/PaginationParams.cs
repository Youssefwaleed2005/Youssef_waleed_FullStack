namespace Assignment_3.Models
{
    public class PaginationParams
    {
        private const int _maxPageSize = 100;
        private int _pageSize=20;

        public int Page {  get; set; }
        public int PageSize
        {
            get {return _pageSize;}
            set {  _pageSize = value>_maxPageSize?_maxPageSize : value; }
        }
    }
}
