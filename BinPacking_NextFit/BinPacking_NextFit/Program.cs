using System;
using System.Collections;

/* 
    First, let's consider the existence of an object called a box. Since the inside of this box occupies a certain area, first that area
    we determine. Then we place objects (packages) in order to fill this box. Back of the box
    If the remaining area is smaller than the size of the package, we create a new box and throw it into the new box. If the size of a package differs from the size of the box
    When it is more, it stays outside because it cannot enter logically, so we cannot put it inside.
 */

/*
    İlk olarak kutu adında bir cismin varlığını düşünelim. Bu kutunun içi belli bir alan yer kapladığı için, ilk o alanı
    belirliyoruz. Daha sonra bu kutunun içini doldurması için SIRASIYLA cisimler(paketler) yerleştiriyoruz. Kutunun geriye
    kalan alanı, paketin boyutundan küçükse yeni bir kutu oluşturup yeni kutunun içine atıyoruz. Eğer bir paketin boyutu, kutunun boyutundan
    daha fazla olduğunda mantıken giremeyeceği için dışarıda kalıyor yani içine koyamıyoruz.
*/

namespace BinPacking_NextFit
{
    class Program
    {
        /// <summary>
        /// Kutunun hacmini , paket sayısının ve paketin boyutunu yani büyüklüğünü kullanıcı tarafından girilerek
        /// paketleme işlemimize başlanacaktır. Try-Catch bloklarıyla ise kullanıcı yanlış değerler girer ise 
        /// kullanıcı uyaracak ve alınabilir değeri girmesi istenecektir.
        /// </summary>
        static void Main(string[] args)
        {
            
            int PaketSayısı=0, KutununKaplayacağıYer=0;
            try
            {
                Console.WriteLine("KUTUNUZUN BOYUTUNU GİRİNİZ ?");
                KutununKaplayacağıYer = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine( "Kutunuza , toplam " +KutununKaplayacağıYer+ " boyutlu paket alabilecek kapasite belirlediniz.. ");
            }
            catch 
            {
                Console.WriteLine(" HATAA... Programı yeniden başlatıp sayısal değer giriniz.");
            }
            try
            {
                Console.WriteLine("KUTUNUN İÇİNE KAÇ TANE PAKET YERLEŞTİRMEK İSTİYORSUNUZ ?");
                PaketSayısı = Convert.ToInt32(Console.ReadLine());
            }
            catch 
            {
                Console.WriteLine(" HATAA... Programı yeniden başlatıp sayısal değer giriniz.");
            }
            int[] paketboyutu = new int[PaketSayısı];
            Console.WriteLine("PAKETLERİNİZİN BOYUTLARINI GİRİNİZ ");
            for (int i = 0; i < PaketSayısı; i++)
            {
                Console.Write((i+1)+ ". paket boyutu = ");
                paketboyutu[i] = Convert.ToInt32(Console.ReadLine());
            }
            MyNextFit myNextFit = new MyNextFit();
            myNextFit.İslem(paketboyutu, PaketSayısı, KutununKaplayacağıYer);
            myNextFit.Bos(paketboyutu, PaketSayısı, KutununKaplayacağıYer);
        }
    }
}
