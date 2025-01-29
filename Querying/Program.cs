using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;


ETicaretContext context = new();

#region En Temel Basit Bir Sorgulama Nasıl Yapılır?
#region Method Syntax
//var urunler = await context.Urunler.ToListAsync();
#endregion
#region Query Syntax
//var urunler2 = await (from urun in context.Urunler
//                      select urun).ToListAsync();
#endregion
#endregion

#region Sorguyu Execute Etmek İçin Ne Yapmamız Gerekmektedir?
#region ToListAsync 
#region Method Syntax
//var urunler = await context.Urunler.ToListAsync();
#endregion
#region Query Syntax
//var urunler = await (from urun in context.Urunler
//select urun).ToListAsync();
#endregion
#endregion

//int urunId = 5;
//string urunAdi = "2";

//var urunler = from urun in context.Urunler
//              where urun.Id > urunId && urun.UrunAdi.Contains(urunAdi)
//              select urun;

//urunId = 200;
//urunAdi = "4";

//foreach (Urun urun in urunler)
//{
//    Console.WriteLine(urun.UrunAdi);
//}

//await urunler.ToListAsync();

#region Foreach

//foreach (Urun urun in urunler)
//{
//    Console.WriteLine(urun.UrunAdi);
//}

#region Deferred Execution(Ertelenmiş Çalışma)
//IQueryable çalışmalarında ilgili kod yazıldığı noktada tetiklenmez/çalıştırılmaz yani ilgili kod yazıldığı noktada sorguyu generate etmez! Nerede eder? Çalıştırıldığı/execute edildiği noktada tetiklenir! İşte bu durumada ertelenmiş çalışma denir!
#endregion
#endregion
#endregion

#region IQueryable ve IEnumerable Nedir? Basit Olarak!

//var urunler = await (from urun in context.Urunler
//                     select urun).ToListAsync();

#region IQueryable
//Sorguya karşılık gelir.
//Ef core üzerinden yapılmış olan sorgunun execute edilmemiş halini ifade eder.
#endregion
#region IEnumerable
//Sorgunun çalıştırılıp/execute edilip verilerin in memorye yüklenmiş halini ifade eder.
#endregion
#endregion

#region Çoğul Veri Getiren Sorgulama Fonksiyonları
#region ToListAsync
//Üretilen sorguyu execute ettirmemizi sağlayan fonksiyondur.

#region Method Syntax
//var urunler = context.Urunler.ToListAsync();
#endregion
#region Query Syntax
//var urunler = (from urun in context.Urunler
//              select urun).ToListAsync();
//var urunler = from urun in context.Urunler
//              select urun;
//var datas = await urunler.ToListAsync();
#endregion
#endregion

#region Where
//Oluşturulan sorguya where şartı eklememizi sağlayan bir fonksiyondur.

#region Method Syntax
//var urunler = await context.Urunler.Where(u => u.Id > 500).ToListAsync();
//var urunler = await context.Urunler.Where(u => u.UrunAdi.StartsWith("a")).ToListAsync();
//Console.WriteLine();
#endregion
#region Query Syntax
//var urunler = from urun in context.Urunler
//              where urun.Id > 500 && urun.UrunAdi.EndsWith("7")
//              select urun;
//var data = await urunler.ToListAsync();
//Console.WriteLine();
#endregion
#endregion

#region OrderBy
//Sorgu üzerinde sıralama yapmamızı sağlayan bir fonksiyondur. (Ascending)

#region Method Syntax
//var urunler = context.Urunler.Where(u => u.Id > 500 || u.UrunAdi.EndsWith("2")).OrderBy(u => u.UrunAdi);
#endregion
#region Query Syntax
//var urunler2 = from urun in context.Urunler
//               where urun.Id > 500 || urun.UrunAdi.StartsWith("2")
//               orderby urun.UrunAdi
//               select urun;
#endregion

//await urunler.ToListAsync();
//await urunler2.ToListAsync();
#endregion

#region ThenBy
//OrderBy üzerinde yapılan sıralama işlemini farklı kolonlarada uygulamamızı sağlayan bir fonksiyondur. (Ascending) 

//var urunler = context.Urunler.Where(u => u.Id > 500 || u.UrunAdi.EndsWith("2")).OrderBy(u => u.UrunAdi).ThenBy(u => u.Fiyat).ThenBy(u => u.Id);

//await urunler.ToListAsync();
#endregion


#region OrderByDescending
//Descending olarak sıralama yapmamızı sağlayan bir fonksiyondur.

#region Method Syntax
//var urunler = await context.Urunler.OrderByDescending(u => u.Fiyat).ToListAsync();
#endregion
#region Query Syntax
//var urunler = await (from urun in context.Urunler
//                     orderby urun.UrunAdi descending
//                     select urun).ToListAsync();
#endregion
#endregion

#region ThenByDescending
//OrderByDescending üzerinde yapılan sıralama işlemini farklı kolonlarada uygulamamızı sağlayan bir fonksiyondur. (Descending)
//var urunler = await context.Urunler.OrderByDescending(u => u.Id).ThenByDescending(u => u.Fiyat).ThenBy(u => u.UrunAdi).ToListAsync();
#endregion
#endregion

#region Tekil Veri Getiren Sorgulama Fonksiyonları
//Yapılan sorguda sade ve sadece tek bir verinin gelmesi amaçlanıyorsa Single ya da SingleOrDefault fonksiyonları kullanılabilir.
#region SingleAsync
//Eğer ki, sorgu neticesinde birden fazla veri geliyorsa ya da hiç gelmiyorsa her iki durumda da exception fırlatır.
#region Tek Kayıt Geldiğinde
//var urun = await context.Urunler.SingleAsync(u => u.Id == 55);
#endregion
#region Hiç Kayıt Gelmediğinde
//var urun = await context.Urunler.SingleAsync(u => u.Id == 5555);
#endregion
#region Çok Kayıt Geldiğinde
//var urun = await context.Urunler.SingleAsync(u => u.Id > 55);
#endregion
#endregion

#region SingleOrDefaultAsync
//Eğer ki, sorgu neticesinde birden fazla veri geliyorsa exception fırlatır, hiç veri gelmiyorsa null döner.
#region Tek Kayıt Geldiğinde
//var urun = await context.Urunler.SingleOrDefaultAsync(u => u.Id == 2212);
#endregion
#region Hiç Kayıt Gelmediğinde
//var urun = await context.Urunler.SingleOrDefaultAsync(u => u.Id == 5555);
#endregion
#region Çok Kayıt Geldiğinde
//var urun = await context.Urunler.SingleOrDefaultAsync(u => u.Id > 12);
#endregion
#endregion

//Yapılan sorguda tek bir verinin gelmesi amaçlanıyorsa First ya da FirstOrDefault fonksiyonları kullanılabilir.
#region FirstAsync
//Sorgu neticesinde elde edilen verilerden ilkini getirir. Eğer ki hiç veri gelmiyorsa HATA fırlatır.
#region Tek Kayıt Geldiğinde
//var urun = await context.Urunler.FirstAsync(u => u.Id == 1);
#endregion
#region Hiç Kayıt Gelmediğinde
//var urun = await context.Urunler.FirstAsync(u => u.Id == 5555);
#endregion
#region Çok Kayıt Geldiğinde
//var urun = await context.Urunler.FirstAsync(u => u.Id > 1);
#endregion
#endregion

#region FirstOrDefaultAsync
//Sorgu neticesinde elde edilen verilerden ilkini getirir. Eğer ki hiç veri gelmiyorsa NULL değerini döndürür.
#region Tek Kayıt Geldiğinde
//var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 55);
#endregion
#region Hiç Kayıt Gelmediğinde
//var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 5555);
#endregion
#region Çok Kayıt Geldiğinde
//var urun = await context.Urunler.FirstAsync(u => u.Id > 55);
#endregion
#endregion

#region SingleAsync, SingleOrDefaultAsync, FirstAsync, FirstOrDefaultAsync Tablo Halinde Karşılaştırması

#endregion

#region FindAsync
//Find fonksiyonu, primary key kolonuna özel HIZLI bir şekilde sorgulama yapmamızı sağlayan bir fonksiyondur.
//Urun urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 55);
//Urun urun = await context.Urunler.FindAsync(12); // direkt parametre olarak ID kolonuna karşılık gelen sütunda arama yapmamıza olanak sağlıyor ve HIZLI bir yöntem.
#region Composite Primary key Durumu
//UrunParca u = await context.UrunParca.FindAsync(10, 23);
#endregion
#endregion

#region FindAsync İle SingleAsync, SingleOrDefaultAsync, FirstAsync, FirstOrDefaultAsync Fonksiyonlarının Tablo Halinde Karşılaştırması

#endregion

#region LastAsync
//Sorgu neticesinde gelen verilerden en SONUNCUSUNU getirir. Eğer ki hiç veri gelmiyorsa HATA fırlatır. OrderBy kullanılması mecburidir.
//var urun = await context.Urunler.OrderBy(u => u.UrunAdi).LastAsync(u => u.Id > 12);
#endregion

#region LastOrDefaultAsync
//Sorgu neticesinde gelen verilerden en sonuncusunu getirir. Eğer ki hiç veri gelmiyorsa NULL döner. OrderBy kullanılması mecburidir.
//var urun = await context.Urunler.OrderBy(u => u.Fiyat).LastOrDefaultAsync(u => u.Id > 55);
#endregion
#endregion

#region Diğer Sorgulama Fonksiyonları
#region CountAsync
//Oluşturulan sorgunun execute edilmesi neticesinde kaç adet satırın elde edileceğini sayısal olarak(int) bizlere bildiren fonksiyondur.
//var urunler = (await context.Urunler.ToListAsync()).Count();
//var urunler = await context.Urunler.CountAsync(); // IQueryable olan bir sorgu üzerinden CountAsync fonksiyonunu kullanarak IQueryable olan sorguya direkt olarak Count fonksiyonunu dahil ediyoruz ve bu da performansı aşırı derecede etkiliyor. IEnumerable olsaydı verileri önce çekip belleğe alacaktık daha sonra sayısını sayacaktık ki bu çok daha fazla maliyetli bir işlem olacaktı yukarıdaki örnekteki gibi.
#endregion

#region LongCountAsync
//Oluşturulan sorgunun execute edilmesi neticesinde kaç adet satırın elde edileceğini sayısal olarak(long) bizlere bildiren fonksiyondur.
//var urunler = await context.Urunler.LongCountAsync(u => u.Fiyat > 5000); // burada count fonksiyonu içerisinde koşul belirtebileceğimizi gösterdik.
#endregion

#region AnyAsync
//Sorgu neticesinde verinin gelip gelmediğini bool türünde dönen fonksiyondur. SQL kısmında Exist operatörünü çalıştırır, yani o veri var mı yok mu onu görebiliyoruz.
//var urunler = await context.Urunler.Where(u => u.UrunAdi.Contains("1")).AnyAsync();
//var urunler = await context.Urunler.AnyAsync(u => u.UrunAdi.Contains("1"));
#endregion

#region MaxAsync
//Verilen kolonda bulunan max/en büyük değeri getirir. (Kolon türü ne ise geri dönüş değeri ona kolon ile aynı olacaktır, float ise float veya int ise int vs.)
//var fiyat = await context.Urunler.MaxAsync(u => u.Fiyat);
#endregion

#region MinAsync
//Verilen kolondaki min/en küçük değeri getirir.
//var fiyat = await context.Urunler.MinAsync(u => u.Fiyat);
#endregion

#region Distinct
//Sorguda mükerrer/tekrarlı kayıtlar varsa bunları tekilleştiren bir işleve sahip fonksiyondur. Yani aynı veriden 2 tane ve daha fazla varsa bunları tekilleştiriyoruz.
//var urunler = await context.Urunler.Distinct().ToListAsync(); // Fonksiyonları kullanırken geri dönüş türlerine mutlaka bak, ezbere kod yazılmaz. Mesela kodu yazarken Distinct'in IQueryable döndüğünü fark edip bu kodu execute etmek için ToListAsync() fonksiyonunu çağırdık.
#endregion

#region AllAsync
//Bir sorgu neticesinde gelen verilerin, verilen şarta uyup uymadığını kontrol etmektedir. Eğer ki tüm veriler şarta uyuyorsa true, uymuyorsa false döndürecektir.
//var m = await context.Urunler.AllAsync(u => u.Fiyat < 150000);
//var m = await context.Urunler.AllAsync(u => u.UrunAdi.Contains("a"));
#endregion

#region SumAsync
//Vermiş olduğumuz sayısal proeprty'nin toplamını alır.
//var fiyatToplam = await context.Urunler.SumAsync(u => u.Fiyat);
#endregion

#region AverageAsync
//Vermiş olduğumuz sayısal proeprtynin aritmetik ortalamasını alır. (Küsüratlı olabileceğinden dolayı Float türünde değer döndürür.)
var aritmetikOrtalama = await context.Urunler.AverageAsync(u => u.Fiyat);
#endregion

#region Contains
//Like '%...%' sorgusu oluşturmamızı sağlar. (içinde geçen şekilde like sorgusu oluşturmamız sağlar) Where şartı içerisinde kullanmamız gereken türden Contains fonksiyonudur.
//var urunler = await context.Urunler.Where(u => u.UrunAdi.Contains("7")).ToListAsync();
#endregion

#region StartsWith
//Like '...%' sorgusu oluşturmamızı sağlar. Belirttiğimiz şart ile başlayan verileri getirir.
//var urunler = await context.Urunler.Where(u => u.UrunAdi.StartsWith("7")).ToListAsync();
#endregion

#region EndsWith
//Like '%...' sorgusu oluşturmamızı sağlar. Belirttiğimiz şart ile biten verileri getirir.
//var urunler = await context.Urunler.Where(u => u.UrunAdi.EndsWith("7")).ToListAsync();
#endregion
#endregion

#region Sorgu Sonucu Dönüşüm Fonksiyonları
//Bu fonksiyonlar ile sorgu neticesinde elde edilen verileri isteğimiz doğrultusunda farklı türlerde projecsiyon edebiliyoruz.

#region ToDictionaryAsync
//Sorgu neticesinde gelecek olan veriyi bir dictioanry olarak elde etmek/tutmak/karşılamak istiyorsak eğer kullanılır!
//var urunler = await context.Urunler.ToDictionaryAsync(u => u.UrunAdi, u => u.Fiyat);

//ToList ile AYNI amaca hizmet etmektedir. Yani, oluşturulan sorguyu execute edip neticesini alırlar.
//ToList : Gelen sorgu neticesini ENTITY türünde bir koleksiyona(List<TEntity>) dönüştürmekteyken,
//ToDictionary ise : Gelen sorgu neticesini DICTIONARY türünden bir koleksiyona dönüştürecektir.
//Dictionary sayesinde verileri KeyValue kullanarak tutabiliriz.
#endregion

#region ToArrayAsync
//Oluşturulan sorguyu dizi olarak elde eder.
//ToList ile muadil amaca hizmet eder. Yani sorguyu execute eder lakin gelen sonucu entity dizisi  olarak elde eder.
//var urunler = await context.Urunler.ToArrayAsync();
#endregion

#region Select
//Select fonksiyonunun işlevsel olarak birden fazla davranışı söz konusudur:
//1. Select fonksiyonu, generate edilecek sorgunun çekilecek kolonlarını ayarlamamızı sağlamaktadır. 


//var urunler = await context.Urunler.Select(u => new Urun
//{
//    Id = u.Id,
//    Fiyat = u.Fiyat
//}).ToListAsync();

//2. Select fonksiyonu, gelen verileri farklı türlerde karşılamamızı sağlar. T (herhangi bir tür), anonim

//var urunler = await context.Urunler.Select(u => new 
//{
//    Id = u.Id,
//    Fiyat = u.Fiyat
//}).ToListAsync();

// İlla ki bir anonim tip kullanmaya gerek yok istersek CQRS pattern'i de hatırlayarak burada sadece sorgumuza uygun bir class oluşturup onu kullanabiliriz. UrunDetay diye bir class oluşturup onu kullandık.
//var urunler = await context.Urunler.Select(u => new UrunDetay
//{
//    Id = u.Id,
//    Fiyat = u.Fiyat
//}).ToListAsync();

#endregion

#region SelectMany
//Select ile aynı amaca hizmet eder. Lakin, ilişkisel tablolar neticesinde gelen koleksiyonel (ICollection) verileri de tekilleştirip projeksiyon etmemizi sağlar.
//Burada ICollection olan yapımızı SelectMany kısmından önce Include fonksiyonu ile içeri ekledik, daha sonra SelectMany'nin 7 Override olan (koleksiyon, (ana_sinif, koleksiyon_sinif) => new TIP {} ) kullanarak ürün ve parçaları birbirine bağladık ve ardından listeledik. Bu işlem sırasında INNER JOIN yapılır.

//var urunler = await context.Urunler.Include(u => u.Parcalar).SelectMany(u => u.Parcalar, (u, p) => new
//{
//    u.Id,
//    u.Fiyat,
//    p.ParcaAdi
//}).ToListAsync();
#endregion
#endregion

#region GroupBy Fonksiyonu
//Gruplama yapmamızı sağlayan fonksiyondur.
#region Method Syntax
//var datas = await context.Urunler.GroupBy(u => u.Fiyat).Select(group => new
//{
//    Count = group.Count(),
//    Fiyat = group.Key // GroupBy içerisinde KEY fonksiyonu gruplama işlemini yaptığımız kolonun değerini elde edebiliyoruz.
//}).OrderByDescending(u=> u.Count).ToListAsync(); // GroupBy kısmına kadar iş bitiyor daha sonraki anonim tür kullanarak projekte etme işlemimizi select ile yapıyoruz.
#endregion
#region Query Syntax

//var datas = await (from urun in context.Urunler
//                   group urun by urun.Fiyat // gruplamak istediğimiz şey "urun", urun içerisinde "Fiyat" kolonunu gruplayacağız.
//            into gruplandirilmisVeri // burada yaptığımız gruplandırmaya bir isim veriyoruz. "gruplandirilmisVeri" ismini verdik.
//                   select new
//                   {
//                       Fiyat = gruplandirilmisVeri.Key,
//                       Count = gruplandirilmisVeri.Count()
//                   }).ToListAsync();

#endregion
#endregion

#region Foreach Fonksiyonu
//Bir sorgulama fonksiyonu felan değildir!
//Sorgulama neticesinde elde edilen koleksiyonel veriler üzerinde iterasyonel olarak dönmemizi ve teker teker verileri elde edip işlemler yapabilmemizi sağlayan bir fonksiyondur. foreach döngüsünün metot halidir!

//foreach (var item in datas)
//{

//}
//datas.ForEach(x =>
//{
    // x iterasyonu ile içeri girdik istediğimiz parametreye x. diyip ulaşabiliriz.
//});
#endregion

Console.WriteLine();

public class ETicaretContext : DbContext
{
    public DbSet<Urun> Urunler { get; set; }
    public DbSet<Parca> Parcalar { get; set; }
    public DbSet<UrunParca> UrunParca { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=BAYDEMIRPC; Database=ETicaretDB2;Trusted_Connection=True; Encrypt=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UrunParca>().HasKey(up => new { up.UrunId, up.ParcaId });
    }
}
public class Urun
{
    public int Id { get; set; }
    public string UrunAdi { get; set; }
    public float Fiyat { get; set; }

    public ICollection<Parca> Parcalar { get; set; }
}
public class Parca
{
    public int Id { get; set; }
    public string ParcaAdi { get; set; }
}
public class UrunParca
{
    public int UrunId { get; set; }
    public int ParcaId { get; set; }

    public Urun Urun { get; set; }
    public Parca Parca { get; set; }
}

public class UrunDetay
{
    public int Id { get; set; }
    public float Fiyat { get; set; }
}