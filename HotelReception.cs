using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Tema2Console
{
    public class HotelReception
    {
        public decimal FinalPrice { get; set; }

        Writer wr =new Writer();

        Database db=new Database();

        public void ProcessOrder()
        {
            wr.write("Start processing...");

            wr.write("Loading order from file...");
            var dataJson = File.ReadAllText("orders.json");
            

            wr.write("Deserializing Order object from json data...");
            List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(dataJson, new StringEnumConverter());

            foreach(Order order in orders)
            {
                if (order == null)
                {
                    wr.write("Order type not parsed successfully.");
                   
                }
                else{
                    if(order.processOrder())
                    {
                        db.addOrder(order);
                    }
                }
                
            }



            wr.write("Rating completed.");

            db.writeOrders();

            wr.write(db.readOrders());
        }
    }
}
