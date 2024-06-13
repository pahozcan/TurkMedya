Merhabalar ,

Bu uygulamanın amacı bana verilmiş olan 2 adet api den gerekli isteklerin atılması sonucu verilerin frontend e yazılması ve gerekli detayların getirilmesiydi. Bununla alakalı olarak bana verilmiş olan caseler üzerinden gidecek olur ise : 

1-) Anasayfa.json dosyasındaki dataları okuyarak Sayfada 5 adet haber gösterilecek ve sayfalandırma yapılması gerekiyor.

(Örnek: 25 haber varsa 5 sayfa yapar..  <geri> 1,2,3,4,5  <ileri> şeklinde bir sayfalandırma yapılması gerekiyor).

Bu case ile alakalı pagination mantığını kullandım. Ve toplam item sayısı 80 adet olduğu için 16 adet sayfa olması gerekiyordu. Bununla beraber bir "int pageSize = 5" değişkeni oluşturdum ve bu değişken ile her sayfada 5 adet itemın gösterilmesi isteğini yerine getirmek adına bunu sağladım. 

Bununla alakalı pagination modelimi oluşturdum ve gerekli itemİndexlerini de bununla kontrol ettim. Bu modelim de yine farklı veri tiplerinden faydalandım. 

Bunun yanında index.cshtmldeki verilerin gerekli apiye istek atılması ve oradan gelen verinin modele eklenip frontend de gözükmesi için ise bir service katmanından faydalandım.

2-) Anasayfamızda filtreleme olmalı, Kategorisine göre (Gündem, Dünya, Spor) ve Anahtar kelimeye göre(sadece başlıkta) filtreleyebilmeli

(Örnek: Gundem 'e basıp filtrele butonuna bastığımda sadece gundem haberleri gelecek. Gundem 'e basıp anahtar kelime erdoğan yazdığımda başlıkta erdoğan geçen gundem haberleri gelecek)


Filtreleme konusu için ise HomeController.cs sayfamda oluşturmuş olduğum 2 adet input ile ; 1 tanesi combobox (buraya bana verilen jsondaki bütün kategorilerin gelmesini "GetCategoryTitles" fonksiyonu ile sağladım) bunun yanında bir de titleların aranması için bir textbox kullanarak yardım aldım. Textbox a girilen veriyi html sayfamın en altında bulunan js fonksitonları ile kontrol ettikten sonra keywordleri homeController da yer alan filterData fonksiyonuma gönderip gerekli filtrelemeyi yapmasını sağladım.



3-)Haber detay case i ile alakalı ise öncelikle her item ın id sine ihtiyacım vardı ve gerekli id leri alıp karışılaştırıp ona göre de detay sayfamın açılmasını sağladım. Bununla alakalı da yine HomeController.cs sayfamda çağırmış olduğum "GetNewsItemAsync" metodumu service katmanında id lerinin aynı olup olmadığına göre kontrol edip ona göre verileri modele gönderip gerekli işlemlerin sonrasında frontend kısmında gösterilmesini sağladım.

4-) Anasayfa ve detay için tasarım yapılmasına gerek yok.Basit bir html’de gösterebilirsiniz.

Bu case ile alakalı olarak özenle TürkMedya renklerini (Kırmızı-Beyaz) kullanmaya ve bunun yanında da haberlerin düzgün gözükmesi adına table componentinden faydalandım.

Son olarak projede katmanlı bir mimari yapısı kullandığımı düşünüyorum. Umarım belirtmiş olduğunuz caseleri doğru ve anlaşılır bir şekilde yerine getirmişimdir. 

Okuduğunuz için teşekkür ederim.

HARUN ÖZCAN