namespace TightlyVSLooselyCoupled
{
    public class Oyuncu
    {
        public void Giy(IKiyafet kiyafet) { }
    }

    public interface IKiyafet
    {

    }

    public class Ayakkabi : IKiyafet
    {

    }
    public class UstGiyim : IKiyafet
    {

    }
    public class Kazak : UstGiyim
    {

    }
    public class KirmiziKazak : Kazak
    {

    }
}
