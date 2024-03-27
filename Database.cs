namespace Tema2Console
{
    public class Database:IDatabase
    {
        List<Order> comenzi;

        public Database()
        {
            comenzi=new List<Order>();
        }
        

        public void addOrder(Order order)
        {
            comenzi.Add(order);
        }
       public void writeOrders()
       {
        using (StreamWriter sw=new StreamWriter("Orders.txt"))
        {
            foreach(Order ord in comenzi)
            {
                sw.WriteLine(ord.Type.ToString()+"\n");
            }
            
        }
        
       }

       public string readOrders()
       {
        using(StreamReader sr=new StreamReader("Orders.txt"))
        {
            string line=sr.ReadToEnd();
            return line;
        }
        
        
        
       }

    }
}