Class Library projesi ile ASP.NET Web Application (.NET Framework) projelerini birbirlerine bağlamak ve Class Library projesinde oluşturulan
BaseRepository dosyalarına erişmek için ASP projesine:

SağTık -> Add -> Reference -> Projects kısmında Framework adlı (Class Library) proje işaretlenip eklenir.

_______________________________________________________________________________________________________________________________________________

_Layoutpage dosyasına:

      <li><a href="/Degree/List">Degree</a></li>
      <li><a href="/Country/List">Country</a></li>

kod satırları eklenir.

_______________________________________________________________________________________________________________________________________________

ASP projesine Properties kısmında SQL bağlantısı tanımlanır. (connectionString)
