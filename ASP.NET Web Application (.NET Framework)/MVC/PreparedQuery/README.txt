Class Library projesi ile ASP.NET Web Application (.NET Framework) projelerini birbirlerine bağlamak ve Class Library projesinde oluşturulan
BaseRepository dosyalarına erişmek için ASP projesine:

SağTık -> Add -> Reference -> Projects kısmında Framework adlı (Class Library) proje işaretlenip eklenir.

_______________________________________________________________________________________________________________________________________________

_Layoutpage dosyasına:

      <li><a href="/Degree/List">Degree</a></li>
      <li><a href="/Country/List">Country</a></li>

kod satırları eklenir.

_______________________________________________________________________________________________________________________________________________

SQL Bağlantısı: Dapper
ManualQuery -> SağTık -> Properties -> Settings -> Add
Type = (ConnectionString)
Value = Sağdaki ...'dan ServerName'e SQL'deki ServerName'i Copy-Paste, "select or enter a database name" kısmında da bağlamak istenilen database seçilir.
Kaydedildiği zaman Web.config dosyası içerisine otomatik olarak <connectionString> tag'ı eklenir.
<connectionString> tag'ı içindeki name, "Connection" olarak değiştirilmelidir. Çünkü DbConnect'te o isim verildi!
