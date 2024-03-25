namespace ShoppingCartApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClothingProduct shirt = new ClothingProduct("Casual Shirt", 199.99, ProductCategory.Clothing, "Medium", "Black");
            ElectronicsProduct laptop = new ElectronicsProduct("Laptop", 14999.99, ProductCategory.Electronics, "hp", "EliteBook");

            // Display product information
            Console.WriteLine("Product Information:");
            shirt.GetInfo();
            laptop.GetInfo();
            Console.WriteLine();

            // Create a shopping cart with a capacity of 5
            ShoppingCart cart = new ShoppingCart(10);

            // Add products to the shopping cart
            cart.AddProduct(shirt);
            cart.AddProduct(laptop);
            Console.WriteLine($"Items in the shopping cart: {cart.ItemCount}");
            Console.WriteLine();

            // Display products in the shopping cart
            Console.WriteLine("Products in the Shopping Cart:");
            foreach (Product product in cart.Products)
            {
                if (product != null)
                    product.GetInfo();
            }
            Console.WriteLine();

            // Remove a product from the shopping cart
            cart.RemoveProduct(shirt);
            Console.WriteLine($"Items in the shopping cart: {cart.ItemCount}");
            Console.WriteLine();

            // Display updated products in the shopping cart
            Console.WriteLine("Updated Products in the Shopping Cart:");
            foreach (Product product in cart.Products)
            {
                if (product != null)
                    product.GetInfo();
            }
        }
        public enum ProductCategory
        {
            Clothing,
            Electronics,
            Home,
            Beauty,
            Groceries
        }

        public class Product
        {
            private string name;
            private double price;
            private ProductCategory category;

            public string Name => name;
            public double Price => price;
            public ProductCategory Category => category;

            public Product(string name, double price, ProductCategory category)
            {
                this.name = name;
                this.price = price;
                this.category = category;
            }

            public virtual void GetInfo()
            {
                Console.WriteLine($"Name: {Name}, Price: {Price:C}, Category: {Category}");
            }
        }

        public class ClothingProduct : Product
        {
            private string size;
            private string color;

            public string Size => size;
            public string Color => color;

            public ClothingProduct(string name, double price, ProductCategory category, string size, string color)
                : base(name, price, category)
            {
                this.size = size;
                this.color = color;
            }

            public override void GetInfo()
            {
                base.GetInfo();
                Console.WriteLine($"Size: {Size}, Color: {Color}");
            }
        }

        public class ElectronicsProduct : Product
        {
            private string brand;
            private string model;

            public string Brand => brand;
            public string Model => model;

            public ElectronicsProduct(string name, double price, ProductCategory category, string brand, string model)
                : base(name, price, category)
            {
                this.brand = brand;
                this.model = model;
            }

            public override void GetInfo()
            {
                base.GetInfo();
                Console.WriteLine($"Brand: {Brand}, Model: {Model}");
            }
        }

        public class ShoppingCart
        {
            private Product[] products;
            private int itemCount;

            public Product[] Products => products;
            public int ItemCount => itemCount;

            public ShoppingCart(int capacity)
            {
                products = new Product[capacity];
                itemCount = 0;
            }

            public void AddProduct(Product product)
            {
                if (itemCount < products.Length)
                {
                    products[itemCount] = product;
                    itemCount++;
                    Console.WriteLine($"{product.Name} added to the shopping cart.");
                }
                else
                {
                    Console.WriteLine("Shopping cart is full. Cannot add more items.");
                }
            }

            public void RemoveProduct(Product product)
            {
                int index = Array.IndexOf(products, product);
                if (index != -1)
                {
                    Array.Copy(products, index + 1, products, index, itemCount - index - 1);
                    itemCount--;
                    Console.WriteLine($"{product.Name} removed from the shopping cart.");
                }
                else
                {
                    Console.WriteLine($"{product.Name} not found in the shopping cart.");
                }
            }
        }
    }
}
