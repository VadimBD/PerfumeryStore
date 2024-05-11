namespace PerfumeryStore.Models
{
    public class Cart
    {

        private List<CartLine> LineCollection = new List<CartLine>();

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = LineCollection.Where(p => p.Product.Id == product.Id).FirstOrDefault();

            if (line == null)
            {
                LineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Product product) => LineCollection.RemoveAll(l => l.Product.Id == product.Id);
        public virtual float ComputeTotalValue() => LineCollection.Sum(e => e.Product.Price * e.Quantity);
        public virtual void Clear() => LineCollection.Clear();
        public virtual IEnumerable<CartLine> Lines => LineCollection;
    }

    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}

