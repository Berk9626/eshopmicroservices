namespace Catalog.API.Model
{
    //postgresql ve martin library kullanacağız
    public class Product
    {
        public Guid Id { get; set; }// these Id propertysi sanki document db deki, document ıd gibi davranacak
        //yani databasedeki yönettiğimiz document id olacak.
        public string Name { get; set; } = default!; //nullable referans türlerinde varsayılan değeri belirtmek için kullanılır. default! ifadesi, nullable referans türlerinde null olarak kabul edilmez ve bu türlerde null olmayan bir varsayılan değer sağlar. Yani, string, Guid gibi referans türleri varsayılan olarak null olabilirken, default! ifadesi bu durumu geçersiz kılar ve varsayılan olarak atanacak bir değer belirler. Bu durumda Name ve Description özellikleri için kullanılmış.
        public List<string> Category { get; set; } = new();// bir sınıfın veya yapısal türün varsayılan oluşturucusunu çağırarak yeni bir örnek oluşturur. Bu özellik, sınıfın varsayılan oluşturucusunu çağırarak bir koleksiyon (List, Dictionary vb.) oluşturmak için kullanılır. Bu durumda Category özelliği için kullanılmış ve bir boş liste oluşturulmuş.
        public string Description { get; set; } = default!;
        public string ImageFile { get; set; } = default!;
        public decimal Price { get; set; } 


    }
}
