namespace Assignment
{
    public class Pack
    {
        private readonly InventoryItem[] _items; // You can use another data structure here if you prefer.
        // You may need another private member variable if you use an array data structure.

        private readonly int _maxCount; // Maximum number of items the pack can hold

        private readonly float _maxVolume; // Maximum volume the pack can hold
        private readonly float _maxWeight; // Maximum weight the pack can hold
        private int _currentCount; // Current number of items in the pack (defaults to 0)
        private float _currentVolume; // Current total volume of items in the pack
        private float _currentWeight; // Current total weight of items in the pack
        private string _packName;

        // Default constructor sets the maxCount to 10 
        // maxVolume to 20 
        // maxWeight to 30
        public Pack() : this(10, 20, 30) { }

        // This constructor is not complete, but it is a good start.
        public Pack(int maxCount, float maxVolume, float maxWeight)
        {
            _items = new InventoryItem[maxCount]; // Initialize the array with the maximum count
            _maxCount = maxCount; // Set the maximum count
            _maxVolume = maxVolume; // Set the maximum volume
            _maxWeight = maxWeight; // Set the maximum weight
            _packName = "Default Pack"; // Set the pack name to a default value
        }

        // This is called a getter
        public int GetMaxCount()
        {
            return _maxCount;
        }
        // Getter for retrieving the current volume of items in the pack
        public float GetVolume()
        {
            return _currentVolume;
        }
        // Method to add an inventory item to the pack
        public bool Add(InventoryItem item)
        {
            // In the `Add` method, check if adding the item would exceed the pack's 
            // maximum count, weight, or volume. If it would not exceed these limits, 
            // add the item to the pack and return `true`. Otherwise, return `false`.

            // Does the current item cause _currentCount to be > _maxCount ... same for vol. and weight
            // if the new item will exceed these parameters, return false
            // else add it to the _items array and return true.

            // Do your logic to ensure the item can be added
            float weight = item.GetWeight();
            float volume = item.GetVolume();
            if (volume <= _maxVolume)
            {
                _currentWeight += weight; // Add the item's weight to the current weight
                _currentVolume += volume; // Add the item's volume to the current volume
                _items[_currentCount++] = item; // Add the item to the array and increment the current count
                return true; // Item added successfully, return true

            }
            return false;
        }

        // Override ToString() method to provide a string representation of the pack
        public override string ToString()
        {
            // Implement the logic to convert the object to a string representation
            // Return the formatted string representing the object
            return "Pack: " + _packName;
        }
    }

    // Abstract class representing an inventory item
    public abstract class InventoryItem
    {
        private readonly float _volume; // Volume of the item
        private readonly float _weight; // Weight of the item
        // Constructor to initialize the volume and weight of the item
        protected InventoryItem(float volume, float weight)
        {
            if (volume <= 0f || weight <= 0f)
            {
                throw new ArgumentOutOfRangeException($"An item can't have {volume} volume or {weight} weight");
            }
            _volume = volume; // Set the volume

            _weight = weight; // Set the weight
        }

        // Abstract method to display the quantities of the item (volume and weight)
        public abstract string Display();

        // Getters
        public float GetVolume()
        {
            return _volume;
        }
        // Getter for retrieving the weight of the item
        public float GetWeight()
        {
            return _weight;
        }
    }

    // Implement these classes - each inherits from InventoryItem
    // 1 line of code each - call base class constructor with appropriate arguments
    public class Arrow : InventoryItem
    {
        public Arrow() : base(0.5f, 0.1f) { }

        public override string Display()
        {
            return $"An arrow with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    public class Bow : InventoryItem
    {
        public Bow() : base(1f, 4f) { }

        public override string Display()
        {
            return $"A bow with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    public class Rope : InventoryItem
    {
        public Rope() : base(1f, 1.5f) { }

        public override string Display()
        {
            return $"A rope with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    public class Water : InventoryItem
    {
        public Water() : base(2f, 3f) { }

        public override string Display()
        {
            return $"Water with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    public class Food : InventoryItem
    {
        public Food() : base(1f, 0.5f) { }

        public override string Display()
        {
            return $"Yummy food with weight {GetWeight()} and volume {GetVolume()}";
        }
    }

    public class Sword : InventoryItem
    {
        public Sword() : base(5f, 3f) { }

        public override string Display()
        {
            return $"A sharp sword with weight {GetWeight()} and volume {GetVolume()}";
        }
    }
}
