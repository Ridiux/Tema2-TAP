namespace Tema2Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Writer wr=new Writer();
            wr.write("Starting Client...");

            var hotelReception = new HotelReception();
            hotelReception.ProcessOrder();

            
        }
    }
}
