using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHRS_ApplicationEntityLayer.PagingListModels
{
    public class PaginatedList<T>:List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public List<T> ItemList { get; set; }
        public bool PreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        public bool NextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
        public PaginatedList(List<T> items,int count,int pageIndex,int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count /(double)pageSize);
            this.AddRange(items);
            ItemList = items;
        }
        public static PaginatedList<T> Create(List<T> data,int pageIndex,int pageSize)
        {
            var count = data.Count;
            //bulunduğum sayfadan bir eksiltip sayfada kaç tane data göstermek istiyorsa o kadarını al
            //linq
            var items = data.Skip((pageIndex - 1) * pageSize) //sayfa sayısının bir eksigi ile kac data görmek istiyorsak o kadar veriyi çarpıp o kadar datayı atla yani 3.sayfadayım 2 sayfa geçti her sayfada 4 veri olsun 8 data gitti
                .Take(pageSize).ToList();  //sayfada kaç veri görmek istiyorsak o kadar veriyi al sayfada göster yani 9.datadan başla
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
