namespace Tema2Console
{
    public class Order
    {
        public OrderType Type { get; set; }

        public int Quantity { get; set; }  
        
        public decimal Price { get; set; }   
        
        public string ReservationDate { get; set; }  
        
        public string Name { get; set; }   
        
        public string ServingDate { get; set; }

        Writer wr=new Writer();

        public bool processOrder()
        {

            
            
            decimal FinalPrice=0;
            switch (Type)
            {
                case OrderType.Room:
                    wr.write("Processing Room order...");

                    wr.write("Validating order parameters...");

                    if (Quantity == 0)
                    {
                        wr.write("-Room order must specify Quantity");
                        return false;
                    }

                    if (Price == 0)
                    {
                        wr.write("-Room order must specify Price");
                        return false;
                    }

                    if (string.IsNullOrEmpty(ReservationDate))
                    {
                        wr.write("-Room order must specify Reservation Date");
                        return false;
                    }

                    if (!DateTime.TryParseExact(ReservationDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var pasedReservationDate))
                    {
                        wr.write("-Reservation Date must be a valid date");
                        return false; 

                    }

                    if (pasedReservationDate < DateTime.Now.AddMonths(1))
                    {
                        FinalPrice = (Quantity * Price)* 0.9m;
                    }
                    else if (pasedReservationDate < DateTime.Now.AddMonths(2))
                    {
                        FinalPrice = (Quantity * Price) * 0.8m;
                    }
                    else
                    {
                        FinalPrice = Quantity * Price;
                    }
                    if (FinalPrice == 0)
                    {
                        wr.write("No order was processed.");
                        return false;
                    }
                    else
                    {
                        wr.write($"Final price for you order: {FinalPrice} RON");
                        return true;
                    }

                    break;
                case OrderType.Product:
                    wr.write("Processing Product order...");

                    wr.write("Validating order parameters...");

                    if (string.IsNullOrEmpty(Name))
                    {
                        wr.write("-Product order must specify Name");
                        return false;
                    }

                    if (Quantity == 0)
                    {
                        wr.write("-Product order must specify Quantity");
                        return false;
                    }

                    if (Price == 0)
                    {
                        wr.write("-Product order must specify Price");
                        return false;
                    }

                    var price = Quantity * Price;
                    if (Name == "Fanta")
                    {
                        price *= 0.75m;
                    }

                    FinalPrice = price;
                    if (FinalPrice == 0)
                    {
                        wr.write("No order was processed.");
                        return false;
                    }
                    else
                    {
                        wr.write($"Final price for you order: {FinalPrice} RON");
                        return true;
                    }
                    
                    break;

                case OrderType.Breakfast:
                    wr.write("Processing Breakfast order...");

                    wr.write("Validating order parameters...");

                    if (Quantity == 0)
                    {
                        wr.write("-Breakfast order must specify Quantity");
                        return false;
                    }

                    if (Price == 0)
                    {
                        wr.write("-Breakfast order must specify Price");
                        return false;
                    }

                    if (string.IsNullOrEmpty(ServingDate))
                    {
                        wr.write("-Room order must specify Serving Date");
                        return false;
                    }

                    if (!DateTime.TryParseExact(ServingDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var pasedServingDate))
                    {
                        wr.write("-Serving Date must be a valid date");
                        return false;
                    }

                    if (pasedServingDate < DateTime.Now.AddDays(7))
                    {
                        FinalPrice = Quantity * Price;
                    }
                    else
                    {
                        FinalPrice = (Quantity * Price) * 0.5m;
                    }
                    if (FinalPrice == 0)
                    {
                        wr.write("No order was processed.");
                        return false;
                    }
                    else
                    {
                        wr.write($"Final price for you order: {FinalPrice} RON");
                        return true;
                    }
                    break;

                default:

                    wr.write("Unknown order type.");
                    return false;
                    break;
            }
        }     
    }
}
